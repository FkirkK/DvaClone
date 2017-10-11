

class Dimensionalizer:

    def __init__(self):
        self.dimensionSet = set()
        self.mappingDictionary = {} #  Remember to call CreateDictionaryOfWords in dimensionalizeAll method
        self.numberOfNGramsInDict = 0

    def DimensionalizeReviewBigramPlus(self, review):
        BigramPlusSet = self.GetBigramsPlusFromReview(review)

        self.dimensionSet = self.dimensionSet.union(BigramPlusSet)


    def DimensionalizeAllReviewsBigramPlus(self, reviewList):
        for review in reviewList:
            self.DimensionalizeReviewBigramPlus(review)
        self.CreateDictionaryOfWords()

    def GetBigramsPlusFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = self.__RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 1):
            returnSet.add(splitContent[i])
            returnSet.add(splitContent[i] + " " + splitContent[i + 1])
        returnSet.add(splitContent[len(splitContent) - 1])  # Done to get last element not caught in loop

        return returnSet

    def __RemoveAllNewlines(self, contentList):
        returnList = []
        for i in range(0, len(contentList)):
            if contentList[i] != "\n" and contentList[i] != "":
                returnList.append(contentList[i])
        return returnList

    def CreateDictionaryOfWords(self):
        # SetUp
        extraSet = self.dimensionSet.copy()
        if len(self.mappingDictionary.keys()) > 0:
            self.mappingDictionary = {}

        # Iterate through extra set and add elements to mappingDict
        for i in range(len(self.dimensionSet)):
            NGram = extraSet.pop()
            self.mappingDictionary[NGram] = i

        # Update NGram-number before returning
        self.numberOfNGramsInDict = len(self.dimensionSet)



