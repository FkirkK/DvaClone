from unittest import TestCase
from OpinionSpamPackage import DvaClassifierTree, OpSpamReader, ClassifierResult


class DvaClassifierTreeTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.classifierTree = DvaClassifierTree(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.classifierTree.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.classifierTree.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange

        # Act
        classifierResult = self.classifierTree.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)

