from unittest import TestCase
from OpinionSpamPackage import DvaNaiveBayesClassifier, OpSpamReader, ClassifierResult


class DvaNaiveBayesClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.naiveBayesClassifier = DvaNaiveBayesClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.naiveBayesClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.naiveBayesClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.naiveBayesClassifier.Do5FoldValidation()
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
        expectedTrueTruthfulCount = 591
        expectedFalseTruthfulCount = 351
        expectedTrueDeceitfulCount = 449
        expectedFalseDeceitfulCount = 209

        # Act
        classifierResult = self.naiveBayesClassifier.Do5FoldValidation()

        # Assert
        self.assertEqual(expectedTrueTruthfulCount, classifierResult.trueTruthful)
        self.assertEqual(expectedFalseTruthfulCount, classifierResult.falseTruthful)
        self.assertEqual(expectedTrueDeceitfulCount, classifierResult.trueDeceitful)
        self.assertEqual(expectedFalseDeceitfulCount, classifierResult.falseDeceitful)