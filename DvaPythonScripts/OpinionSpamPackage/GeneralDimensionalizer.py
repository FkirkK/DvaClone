import numpy


class GeneralDimensionalizer:

    def __init__(self, reviewList, dimensionalizationFunction):
        self.reviewList = reviewList
        self.rowLength = self.reviewList
        self.dimensionalizationFunction = dimensionalizationFunction

    def GetFeatureSet(self, reviewIndexList):
        return self.dimensionalizationFunction(reviewIndexList)

    def RemoveAllNewlines(self, contentList):
        returnList = []
        for i in range(0, len(contentList)):
            if contentList[i] != "\n" and contentList[i] != "":
                returnList.append(contentList[i])
        return returnList

