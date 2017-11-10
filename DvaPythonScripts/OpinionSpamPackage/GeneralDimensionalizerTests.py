from unittest import TestCase

from OpinionSpamPackage import ParagraphDimensionalizer, Review


class GeneralDimensionalizerTests(TestCase):

    @classmethod
    def setUpClass(cls):
        # Arrange
        cls.reviewList = []
        reviewContent1 = "This is the great and awesome sentence. 1t has potential to build a wall. The 1t of this sentence is over 9000."
        reviewContent2 = "This is a good sentence made to poke to the bear."
        review1 = Review(True, True, "King of the world", reviewContent1, 1)
        review2 = Review(True, False, "Queen of the underworld", reviewContent2, 1)
        cls.reviewList.append(review1)
        cls.reviewList.append(review2)

    def test_get_dimensionalized_reviews(self):
        pd = ParagraphDimensionalizer(self.reviewList)

        # Act
        matrix = pd.GetFeatureSet(list(range(0, len(self.reviewList))))

        # Assert
        self.assertEqual((2, 100), matrix.shape)

    def test_get_dimensionalized_reviews_in_range(self):
        pd = ParagraphDimensionalizer(self.reviewList)

        # Act
        matrix = pd.GetFeatureSet([0])

        # Assert
        self.assertEqual((1, 100), matrix.shape)
