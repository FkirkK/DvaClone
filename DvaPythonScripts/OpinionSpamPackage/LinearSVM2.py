import numpy
from sklearn import svm

from OpinionSpamPackage import Dimensionalizer


class DvaLinearSvm:

    def __init__(self, reviewList):
        self.reviewList = reviewList
        self.dimensionalizer = Dimensionalizer()
        self.model = None

    def LearnModel(self):
        # Prepare variables for learning model
        self.dimensionalizer.DimensionalizeAllReviewsBigramPlus(reviewList=self.reviewList)
        n_samples = len(self.reviewList)
        n_features = len(self.dimensionalizer.mappingDictionary.keys())

        # Instantiate input to svm algorithm
        x = numpy.zeros(shape=(n_samples, n_features))  # x will contain all document vectors for training
        y = []  # y will contain classification-value for training vectors

        # Populate x and y
        for i in range(0, n_samples):
            wordSet = self.dimensionalizer.GetBigramsPlusFromReview(review=self.reviewList[i])
            for bigram in wordSet:
                indexInRow = self.dimensionalizer.mappingDictionary[bigram]
                x[i][indexInRow] = 1
            y.append(self.reviewList[i].isTruthful)

        classifier = svm.LinearSVC()
        classifier.fit(X=x, y=y)

        self.model = classifier



    def Do5FoldValidation(self):
        pass

