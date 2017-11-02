from OpinionSpamPackage import DvaGeneralClassifier, UniGramDimensionalizer
from sklearn.tree import DecisionTreeClassifier


class DvaClassifierTree(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=DecisionTreeClassifier())
