from unittest import TestCase
from OpinionSpamPackage import DvaMLPClassifier, OpSpamReader, ClassifierResult


class DvaMLPClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.mLPClassifier = DvaMLPClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.mLPClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.mLPClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.mLPClassifier.Do5FoldValidation()
        actualCount = result.trueTruthful + result.falseTruthful + result.trueDeceitful + result.falseDeceitful

        # Assert
        self.assertTrue(type(result) is ClassifierResult)
        self.assertEqual(expectedCount, actualCount)
        self.assertTrue(result.trueTruthful <= 800)
        self.assertTrue(result.falseTruthful <= 800)
        self.assertTrue(result.trueDeceitful <= 800)
        self.assertTrue(result.falseDeceitful <= 800)

