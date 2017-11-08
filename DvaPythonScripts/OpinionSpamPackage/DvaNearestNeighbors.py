from OpinionSpamPackage import DvaGeneralClassifier, UniGramDimensionalizer
from sklearn.neighbors import KNeighborsClassifier


class DvaNearestNeighborsClassifier(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=KNeighborsClassifier())
