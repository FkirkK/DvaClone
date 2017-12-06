from unittest import TestCase
from OpinionSpamPackage import UniGramDimensionalizer, DvaLinearSvm, DvaPolySvm, DvaRbfSvm, DvaSigmoidSvm, \
    OpSpamReader, DvaSvmLinear, ClassifierResult
from sklearn import svm


class DvaSvmsTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.reviewList = self.osReader.ReadAllFiles()
        self.dimensionalizerClass = UniGramDimensionalizer
        self.linearSVCClassifier = DvaLinearSvm(self.reviewList, self.dimensionalizerClass)

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

    def test_linearSVC_is_model_learned(self):
        # Arrange

        # Act
        self.linearSVCClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.linearSVCClassifier.model is not None)

    def test_linearSVC_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.linearSVCClassifier.Do5FoldValidation()
        actualCount = result.trueTruthful + result.falseTruthful + result.trueDeceitful + result.falseDeceitful

        # Assert
        self.assertTrue(type(result) is ClassifierResult)
        self.assertEqual(expectedCount, actualCount)
        self.assertTrue(result.trueTruthful <= 800)
        self.assertTrue(result.falseTruthful <= 800)
        self.assertTrue(result.trueDeceitful <= 800)
        self.assertTrue(result.falseDeceitful <= 800)

    def test_linearSVC_returns_expected_result_on_unigram(self):
        # Arrange
        expectedTrueTruthfulCount = 670
        expectedFalseTruthfulCount = 126
        expectedTrueDeceitfulCount = 674
        expectedFalseDeceitfulCount = 130

        # Act
        classifierResult = self.linearSVCClassifier.Do5FoldValidation()

        # Assert
        self.assertEqual(expectedTrueTruthfulCount, classifierResult.trueTruthful)
        self.assertEqual(expectedFalseTruthfulCount, classifierResult.falseTruthful)
        self.assertEqual(expectedTrueDeceitfulCount, classifierResult.trueDeceitful)
        self.assertEqual(expectedFalseDeceitfulCount, classifierResult.falseDeceitful)
