import numpy
from sklearn import svm

from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import ClassifierResult


class DvaGeneralClassifier:

    def __init__(self, reviewList, classifier, dimensionalizerClass=BigramPlusDimensionalizer):
        self.reviewList = reviewList
        self.dimensionalizer = dimensionalizerClass(reviewList=self.reviewList)
        self.model = None
        self.__classifier__ = classifier

    def LearnModelForAllReviews(self):
        self.LearnModel(list(range(0, len(self.reviewList))))

    def LearnModel(self, reviewIndexList):
        # Instantiate input to classifier algorithm
        x = self.dimensionalizer.GetFeatureSet(reviewIndexList=reviewIndexList)  # x contains all document vectors for training
        y = []  # y will contain classification-value for training vectors

        # Populate y
        for index in reviewIndexList:
            y.append(self.reviewList[index].isTruthful)

        # Learn and save the classifier
        self.model = self.__classifier__.fit(X=x, y=y)

    # Constructs a list of which reviews to learn the model on
    def __ConstructReviewIndexListFromFolds(self, foldsToInclude):
        reviewIndexList = []

        i = 0
        for review in self.reviewList:
            if review.fold in foldsToInclude:
                reviewIndexList.append(i)
            i += 1

        return reviewIndexList

    def Do5FoldValidation(self):
        numberOfFolds = 5
        listOfResults = []

        for i in range(1, numberOfFolds+1): # 1 indexing for human readability of fold numbers
            reviewIndexListForValidation = self.__ConstructReviewIndexListFromFolds([i])
            reviewIndexListForTraining = self.__ConstructReviewIndexListFromFolds([j for j in range(1, numberOfFolds+1) if j != i])
            validationReviews = [review for review in self.reviewList if review.fold == i]

            # Learn model based on learningReviews --> self.model is set
            self.LearnModel(reviewIndexList=reviewIndexListForTraining)

            # Prepare variables for prediction
            validationReviewCount = len(validationReviews)
            trueTruthfulCount = 0
            falseTruthfulCount = 0
            trueDeceitfulCount = 0
            falseDeceitfulCount = 0
            classifierResultList = []

            # Use model to predict validationReviews
            for reviewIndex in reviewIndexListForValidation:
                review = self.reviewList[reviewIndex]
                reviewVector = self.dimensionalizer.GetFeatureSet(reviewIndexList=[reviewIndex])
                prediction = self.model.predict(reviewVector)
                if prediction[0] and review.isTruthful:
                    trueTruthfulCount += 1
                elif prediction[0] and not review.isTruthful:
                    falseTruthfulCount += 1
                elif not prediction[0] and not review.isTruthful:
                    trueDeceitfulCount += 1
                elif not prediction[0] and review.isTruthful:
                    falseDeceitfulCount += 1
                classifierResultList.append((review.title, review.isTruthful, prediction[0]))

            classifierResult = ClassifierResult(trueTruthful=trueTruthfulCount, falseTruthful=falseTruthfulCount,
                                                trueDeceitful=trueDeceitfulCount, falseDeceitful=falseDeceitfulCount,
                                                reviewList=classifierResultList)
            listOfResults.append(classifierResult)

        return ClassifierResult.AggregateResults(listOfResults)
