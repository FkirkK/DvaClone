from unittest import TestCase

from OpinionSpamPackage import ParagraphDimensionalizer


class GeneralDimensionalizerTests(TestCase):

    def test_get_dimensionalized_reviews(self):
        # Arrange
        reviewList = []
        reviewList.append("This is the great and awesome sentence. 1t has potential to build a wall. The 1t of this sentence is over 9000.")
        reviewList.append("This is a good sentence made to poke to the bear.")
        rangeMin = 0

        pd = ParagraphDimensionalizer(reviewList)

        # Act
        matrix = pd.getFeatureSet(rangeMin, pd.rowLength-1)

        # Assert
        self.assertEqual((2, 100), matrix.shape)

    def test_get_dimensionalized_reviews_in_range(self):
        # Arrange
        reviewList = []
        reviewList.append("This is the great and awesome sentence. 1t has potential to build a wall. The 1t of this sentence is over 9000.")
        reviewList.append("This is a good sentence made to poke to the bear.")
        rangeMin = 0

        pd = ParagraphDimensionalizer(reviewList)

        # Act
        matrix = pd.getFeatureSet(rangeMin, 0)

        # Assert
        self.assertEqual((1, 100), matrix.shape)