import numpy
from OpinionSpamPackage import GeneralDimensionalizer


class BigramPlusDimensionalizer(GeneralDimensionalizer):

    def __init__(self):
        super().__init__(self.GetBigramsPlusFromReview)

    def GetBigramsPlusFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 1):
            returnSet.add(splitContent[i])
            returnSet.add(splitContent[i] + " " + splitContent[i + 1])
        returnSet.add(splitContent[len(splitContent) - 1])  # Done to get last element not caught in loop

        return returnSet
