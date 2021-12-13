text= '''AAOSA JRTIE EAAAU SCEAE IANPIJAJJN FVSOI RZVPH NIONA RNZIJINUSS NTRZU TIC'''
text = text.replace(" ", "")

c = 7 # broj stupaca
r = len(text)//c # broj redaka

keyword= "KRIPTO" #probaj s drugim rijecima

from itertools import repeat
data = [[] for i in repeat(None, r)]

i = 0
for t in text:
    data[i].append(t)
    i+=1
    if i == r:
        i=0

def get(perm):
    new_text=""
    n_rows = [row[:] for row in data]

    for row,new_row in zip(data, n_rows):
        for i,k in enumerate(perm):
             new_row[i]= row[int(k)-1]

    for i in n_rows:
        new_text=new_text+ ''.join(i)

    return new_text

import itertools
for iter in itertools.permutations( list(range(1, c+1))):

    values = ''.join(str(i) for i  in iter)
    recenica = get(values)
    if keyword in recenica:
        print(iter , recenica)




