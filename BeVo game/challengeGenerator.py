import csv
import random

adjectives = ['most fun', 'worst', 'most beautiful', 'easiest', 'bravest', 'highest', 'drunkest',
              'longest', 'shortest', 'fattest', 'best', 'most delicious']
subjects = ['relationship', 'activity', 'experience', 'drinking session', 'food', 'fight', 'trip', 'sit-ups',
            'push-ups', 'sex', 'phone']


with open('light.csv', 'w') as csv_file:
    csv_writer = csv.writer(csv_file, delimiter = ' ') #no delimiter since we want to build our own string based on some lists
    
    for i in range(1000):
        random_adj = random.choice(adjectives)
        random_subj = random.choice(subjects)
        output = ['{0},', 'tell', 'us', 'the', random_adj, random_subj, 'you had in the last', random.randrange(1,5), 'years']
        csv_writer.writerow(output)
