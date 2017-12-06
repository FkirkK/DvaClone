from unittest import TestCase
from OpinionSpamPackage import DvaNearestNeighborsClassifier, OpSpamReader, ClassifierResult


class DvaNearestNeighborsTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.nNClassifier = DvaNearestNeighborsClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.nNClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.nNClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange
        expectedCount = 1600

        # Act
        result = self.nNClassifier.Do5FoldValidation()
        actualCount = result.trueTruthful + result.falseTruthful + result.trueDeceitful + result.falseDeceitful

        # Assert
        self.assertTrue(type(result) is ClassifierResult)
        self.assertEqual(expectedCount, actualCount)
        self.assertTrue(result.trueTruthful <= 800)
        self.assertTrue(result.falseTruthful <= 800)
        self.assertTrue(result.trueDeceitful <= 800)
        self.assertTrue(result.falseDeceitful <= 800)