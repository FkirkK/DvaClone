from unittest import TestCase
from gensim.models import doc2vec
from collections import namedtuple

from OpinionSpamPackage.ParagraphDimensionalizer import ParagraphDimensionalizer


class ParagraphDimensionalizerTests(TestCase):

    def test_can_make_paragraph_vectors(self):
        # Arrange
        docCollection = ["This is a sentence wut wut wut wut wut alalala", "This is another sentence"]
        docs = []
        tags = [1]
        analyzedDocument = namedtuple('AnalyzedDocument', 'words tags')  # Named tuple with typename and fieldnames

        # Act
        tags[0] = 0
        docs.append(analyzedDocument(docCollection[0].split(), tags=tags))  # Tags must be iterable - tag given for each word in document
        tags[0] = 1
        docs.append(analyzedDocument(docCollection[1].split(), tags=tags))

        model = doc2vec.Doc2Vec(docs, size=5, window=300, min_count=1, workers=4)

        # Assert
        self.assertEqual(5, len(model.docvecs[0]))
        self.assertEqual(5, len(model.docvecs[1]))

    def test_can_dimensionalize_review(self):
        # Arrange
        reviewList = []
        reviewList.append("This is the great and awesome sentence. 1t has potential to build a wall. The 1t of this sentence is over 9000.")
        reviewList.append("This is a good sentence made to poke to the bear.")

        pd = ParagraphDimensionalizer(reviewList)

        # Act



