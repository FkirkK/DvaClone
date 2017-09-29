import re

class Review:

    def __init__(self, isTruthful, isPositive, title, content, fold):
        self.isTruthful = isTruthful
        self.isPositive = isPositive
        self.title = title
        self.content = content.lower()
        self.content = re.sub(r'[.,?!:;_()]*', "", self.content)
        self.fold = fold

    def __str__(self):
        if self.isTruthful:
            true = "truthful"
        else:
            true = "deceitful"
        if self.isPositive:
            positive = "positive"
        else:
            positive = "negative"

        return "Review: {title} is a {true} and {positivity} review!".format(title=self.title, true=true, positivity=positive)

    def __repr__(self):
        return self.__str__()
