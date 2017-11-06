from unittest import TestCase
from OpinionSpamPackage import TrigramDimensionalizer, DvaLinearSvm, DvaPolySvm, DvaRbfSvm, DvaSigmoidSvm, Review, \
    DvaSvmLinear
from sklearn import svm


class DvaSvmsTests(TestCase):

    def setUp(self):
        self.reviewList = [Review(True, True, "title", "text", 0)]
        self.dimensionalizerClass = TrigramDimensionalizer

    def test_svm_sets_linear_parameters_correctly(self):
        curSVM = DvaLinearSvm(self.reviewList, self.dimensionalizerClass)
        self.assertEqual(svm.LinearSVC, type(curSVM.__classifier__))

    def test_svm_sets_poly_parameters_correctly(self):
        curSVM = DvaPolySvm(self.reviewList, self.dimensionalizerClass)
        self.assertEqual("poly", curSVM.__classifier__.kernel)

    def test_svm_sets_rbf_parameters_correctly(self):
        curSVM = DvaRbfSvm(self.reviewList, self.dimensionalizerClass)
        self.assertEqual("rbf", curSVM.__classifier__.kernel)

    def test_svm_sets_sigmoid_parameters_correctly(self):
        curSVM = DvaSigmoidSvm(self.reviewList, self.dimensionalizerClass)
        self.assertEqual("sigmoid", curSVM.__classifier__.kernel)

    def test_svm_sets_svm_linear_parameters_correctly(self):
        curSVM = DvaSvmLinear(self.reviewList, self.dimensionalizerClass)
        self.assertEqual("linear", curSVM.__classifier__.kernel)
