import sys
sys.path.append('C:/Users/super/AppData/Local/Programs/Python/Python36-32/Lib/sklearn')
sys.path.append('C:/Users/super/AppData/Local/Programs/Python/Python36-32/Lib');
sys.path.append('C:\Python\Python36-32\Lib\sklearn')
#
import requests
#from requests.auth import HTTPDigestAuth
import json
#import collections;  
from datetime import datetime as dt
from datetime import datetime
import random
# SKLEARN importeren
#py C:\Users\super\OneDrive\Documenten\GitHub\Project78\TamTamSuggestions\TamTamTracker\WebAPI\PythonScripts\machine_learning.py
from sklearn import tree
def GenerateSuggestion():
		# get list of beacon data
		response = requests.get("http://localhost:50798/api/suggestions/GetDataBeacons")
		data = response.json() # get data
		s1 = json.dumps(data)
		x = json.loads(str(s1))
		i = 0;
		features = []
		labels = []
		
		while i < len(x):
			module = (x[i]["module"])
			if module == 'lunch':
				# module 1 = lunch
				module = 1
			else:
				module = 2
			dt_created = (x[i]["dt_created"])
			file = (x[i]["file"])
			school_holiday = (x[i]["school_holiday"])
			amount_of_people = (x[i]["amount_of_people"])
			new_date = dt_created.replace('T', ' ') #remove char T in datetime string for converting
			
			date = dt.strptime(new_date,"%Y-%m-%d %H:%M:%S")
			year = date.strftime("%Y")
			month = date.strftime("%m")
			day   = date.strftime("%d")
			hours  = date.strftime("%H")
			minutes = date.strftime("%M")
			
			#Calculate factors
			day_factor = (int(day)/31 )
			year_factor = (int(year)/ 2018)
			month_factor = (int(month)/12)
			hours_factor = (int(hours)/24)
			minutes_factor = (int(minutes)/60)
			
			features.append([year_factor,month_factor,day_factor,hours_factor, minutes_factor, file ,school_holiday , module])
			labels.append(amount_of_people);
			i += 1
			
		
		#input 
		now = dt.now()
		year = now.strftime("%Y")
		month = now.strftime("%m")
		day   = now.strftime("%d")
		hours  = now.strftime("%H")
		minutes = now.strftime("%M")
			
		#Calculate factors
		day_factor = (int(day)/31 )
		year_factor = (int(year)/ 2018)
		month_factor = (int(month)/12)
		hours_factor = (int(hours)/24)
		minutes_factor = (int(minutes)/60)
		
		if (int(hours) > 8 and int(hours)  < 12) or (int(hours) == 18 or int(hours == 17)):
			file = 1
		else:
			file = 0
		
		strg = '{:%Y-%m-%d}'.format(now)
		
		response = requests.get("http://localhost:50798/api/suggestions/isholiday/" + strg)
		
		data_school_holiday = response.json() # get data

		clf = tree.DecisionTreeClassifier()
		clf = clf.fit(features,labels);
		#print("****************** PREDICT *****************")
		
		suggestion = clf.predict([[year_factor,month_factor,day_factor,hours_factor, minutes_factor, file ,int(data_school_holiday) , 1]])
		print("test")
		#print(suggestion)
		

GenerateSuggestion();

#print("test")
#input of today
#

#numpy  > C:\Users\super\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Python 3.6>py.exe -m pip install numpy
#scipy  > ZElfde links als hierboven alleen ipv numpy /scipy
#sklearn  pip install -U scikit-learn
# Install-Package IronPython
# 
#  Install-Package IronPython.StdLib