import numpy
from sklearn import svm

from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import ClassifierResult


class DvaGeneralSvm:

    def __init__(self, reviewList, classifier, dimensionalizerClass=BigramPlusDimensionalizer):
        self.reviewList = reviewList
        self.dimensionalizer = dimensionalizerClass()
        self.dimensionalizer.DimensionalizeAllReviews(reviewList=self.reviewList)
        self.model = None
        self.__classifier__ = classifier

    def LearnModel(self, reviewListForLearning):
        # Prepare variables for learning model
        n_samples = len(reviewListForLearning)
        n_features = len(self.dimensionalizer.mappingDictionary.keys())

        # Instantiate input to svm algorithm
        x = numpy.zeros(shape=(n_samples, n_features))  # x will contain all document vectors for training
        y = []  # y will contain classification-value for training vectors

        # Populate x and y
        for i in range(0, n_samples):
            wordSet = self.dimensionalizer.nGramGetter(review=reviewListForLearning[i])
            for ngram in wordSet:
                indexInRow = self.dimensionalizer.mappingDictionary[ngram]
                x[i][indexInRow] = 1
            y.append(reviewListForLearning[i].isTruthful)

        # Learn and save the classifier
        self.model = self.__classifier__.fit(X=x, y=y)

    def Do5FoldValidation(self):
        numberOfFolds = 5
        listOfResults = []

        for i in range(1, numberOfFolds+1):  # 1-indexing because it must be human-readable
            learningReviews = []
            validationReviews = []

            # Split reviews based on folds
            for review in self.reviewList:
                if review.fold == i:
                    validationReviews.append(review)
                else:
                    learningReviews.append(review)

            # Learn model based on learningReviews --> self.model is set
            self.LearnModel(reviewListForLearning=learningReviews)

            # Prepare variables for prediction
            validationReviewCount = len(validationReviews)
            correctPredictionCount = 0
            fakePositiveCount = 0
            fakeNegativeCount = 0
            classifierResultList = []

            # Use model to predict validationReviews
            for review in validationReviews:
                reviewVector = self.dimensionalizer.CreateNGramsVectorForReview(review)
                prediction = self.model.predict(reviewVector)
                if prediction[0] == review.isTruthful:
                    correctPredictionCount += 1
                elif prediction[0]:
                    fakePositiveCount += 1
                else:
                    fakeNegativeCount += 1
                classifierResultList.append((review.title, review.isTruthful, prediction[0]))

            classifierResult = ClassifierResult(fold=i, precision=correctPredictionCount/validationReviewCount,
                                                fakePositives=fakePositiveCount/validationReviewCount,
                                                fakeNegatives=fakeNegativeCount/validationReviewCount,
                                                reviewList=classifierResultList)
            listOfResults.append(classifierResult)

        return ClassifierResult.AggregateResults(listOfResults)
