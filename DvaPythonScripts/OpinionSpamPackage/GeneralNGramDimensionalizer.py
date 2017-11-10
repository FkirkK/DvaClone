import numpy

from OpinionSpamPackage import GeneralDimensionalizer


class GeneralNGramDimensionalizer(GeneralDimensionalizer):

    def __init__(self, featureFunction, reviewList):
        super().__init__(reviewList, self.__ConstructFeatureSetInRange)
        self.dimensionSet = set()
        self.mappingDictionary = {}
        self.numberOfNGramsInDict = 0
        self.featureGetter = featureFunction
        self.__DimensionalizeAllReviews(reviewList=reviewList)

    def __DimensionalizeReview(self, review):
        nGramSet = self.featureGetter(review)

        self.dimensionSet = self.dimensionSet.union(nGramSet)

    def __DimensionalizeAllReviews(self, reviewList):
        for review in reviewList:
            self.__DimensionalizeReview(review)
        self.__CreateDictionaryOfWords()

    def __GetVector(self, review):
        vector = numpy.zeros(shape=(1, len(self.mappingDictionary.keys())))
        wordSet = self.featureGetter(review)

        for ngram in wordSet:
            indexInRow = self.mappingDictionary[ngram]
            vector[0][indexInRow] = 1

        return vector

    def __ConstructFeatureSetInRange(self, reviewIndexList):  # reviewIndexList is a list of indexes in the reviewlist
        n_samples = len(reviewIndexList)
        n_features = len(self.mappingDictionary.keys())

        matrix = numpy.zeros(shape=(n_samples, n_features))

        # Setting all rows in matrix to a review vector
        i = 0
        for index in reviewIndexList:
            matrix[i] = self.__GetVector(self.reviewList[index])
            i += 1

        return matrix

    def __CreateDictionaryOfWords(self):
        # SetUp
        extraSet = self.dimensionSet.copy()
        if len(self.mappingDictionary.keys()) > 0:  # Wipes preexisting dictionary.
            self.mappingDictionary = {}

        # Iterate through extra set and add elements to mappingDict
        for i in range(len(self.dimensionSet)):
            NGram = extraSet.pop()
            self.mappingDictionary[NGram] = i

        # Update NGram-number before returning
        self.numberOfNGramsInDict = len(self.dimensionSet)
