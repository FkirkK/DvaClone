from unittest import TestCase
from OpinionSpamPackage import DvaAdaBoostClassifier, DvaBaggingClassifier, OpSpamReader, ClassifierResult


class DvaAdaBoostClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.adaBoostClassifier = DvaAdaBoostClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.adaBoostClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.adaBoostClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.adaBoostClassifier.Do5FoldValidation()
        actualCount = result.trueTruthful + result.falseTruthful + result.trueDeceitful + result.falseDeceitful

        # Assert
        self.assertTrue(type(result) is ClassifierResult)
        self.assertEqual(expectedCount, actualCount)
        self.assertTrue(result.trueTruthful <= 800)
        self.assertTrue(result.falseTruthful <= 800)
        self.assertTrue(result.trueDeceitful <= 800)
        self.assertTrue(result.falseDeceitful <= 800)

    def test_returns_expected_result_on_unigram(self):
        # Arrange
        expectedTrueTruthfulCount = 635
        expectedFalseTruthfulCount = 159
        expectedTrueDeceitfulCount = 641
        expectedFalseDeceitfulCount = 165

        # Act
        classifierResult = self.adaBoostClassifier.Do5FoldValidation()

        # Assert
        self.assertEqual(expectedTrueTruthfulCount, classifierResult.trueTruthful)
        self.assertEqual(expectedFalseTruthfulCount, classifierResult.falseTruthful)
        self.assertEqual(expectedTrueDeceitfulCount, classifierResult.trueDeceitful)
        self.assertEqual(expectedFalseDeceitfulCount, classifierResult.falseDeceitful)


class DvaBaggingClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.baggingClassifier = DvaBaggingClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.baggingClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.baggingClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.baggingClassifier.Do5FoldValidation()
        actualCount = result.trueTruthful + result.falseTruthful + result.trueDeceitful + result.falseDeceitful

        # Assert
        self.assertTrue(type(result) is ClassifierResult)
        self.assertEqual(expectedCount, actualCount)
        self.assertTrue(result.trueTruthful <= 800)
        self.assertTrue(result.falseTruthful <= 800)
        self.assertTrue(result.trueDeceitful <= 800)
        self.assertTrue(result.falseDeceitful <= 800)