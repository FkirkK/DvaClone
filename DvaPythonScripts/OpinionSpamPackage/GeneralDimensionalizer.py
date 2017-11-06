import numpy


class GeneralDimensionalizer:

    def __init__(self, featureFunction, reviewList):
        self.dimensionSet = set()
        self.mappingDictionary = {}  # Remember to call CreateDictionaryOfWords in dimensionalizeAll method
        self.numberOfNGramsInDict = 0
        self.featureGetter = featureFunction
        self.__DimensionalizeAllReviews(reviewList=reviewList)

    def __DimensionalizeReview(self, review):
        nGramSet = self.featureGetter(review)

        self.dimensionSet = self.dimensionSet.union(nGramSet)

    def __DimensionalizeAllReviews(self, reviewList):
        for review in reviewList:
            self.__DimensionalizeReview(review)
        self.CreateDictionaryOfWords()

    def CreateVectorForReview(self, review):
        vectorToPredict = numpy.zeros(shape=(1, self.numberOfNGramsInDict))
        setToPopulateVector = self.featureGetter(review)
        for nGram in setToPopulateVector:
            indexInVector = self.mappingDictionary[nGram]
            vectorToPredict[0][indexInVector] = 1

        return vectorToPredict

    def RemoveAllNewlines(self, contentList):
        returnList = []
        for i in range(0, len(contentList)):
            if contentList[i] != "\n" and contentList[i] != "":
                returnList.append(contentList[i])
        return returnList

    def CreateDictionaryOfWords(self):
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
