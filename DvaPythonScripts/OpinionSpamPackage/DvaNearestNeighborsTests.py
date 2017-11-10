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

        # Act
        classifierResult = self.nNClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)