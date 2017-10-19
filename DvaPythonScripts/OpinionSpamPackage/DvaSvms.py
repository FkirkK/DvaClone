from OpinionSpamPackage import DvaGeneralSvm
from OpinionSpamPackage import BigramPlusDimensionalizer
from sklearn import svm


class DvaLinearSvm(DvaGeneralSvm):

    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, SvmClass=svm.LinearSVC)