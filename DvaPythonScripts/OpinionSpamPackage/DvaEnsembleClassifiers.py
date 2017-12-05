from OpinionSpamPackage import DvaGeneralClassifier, UniGramDimensionalizer
from sklearn.ensemble import AdaBoostClassifier, BaggingClassifier


class DvaAdaBoostClassifier(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=AdaBoostClassifier())

class DvaBaggingClassifier(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=BaggingClassifier())