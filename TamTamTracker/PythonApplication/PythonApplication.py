import sys
from sklearn import tree
import requests
import json 
from datetime import datetime as dt
from datetime import datetime
import random

def GenerateSuggestion():
        # Get list of beacon data from API
        response = requests.get("http://localhost:50798/api/suggestions/GetDataBeacons")

        # Set response to json
        data = response.json()
        s1 = json.dumps(data)
        x = json.loads(str(s1))
        i = 0;
        features = []
        labels = []

        while  i < len(x):
            module = (x[i]["module"])
            if module == 'lunch':
               module = 1
            else:
               module = 2

            dt_created        = (x[i]["dt_created"])
            file              = (x[i]["file"])
            school_holiday    = (x[i]["school_holiday"])
            amount_of_people  = (x[i]["amount_of_people"])

            # Remove char T in DateTime string for converting
            new_date       = dt_created.replace('T', ' ')
            date           = dt.strptime(new_date,"%Y-%m-%d %H:%M:%S")
            year           = date.strftime("%Y")
            month          = date.strftime("%m")
            day            = date.strftime("%d")
            hours          = date.strftime("%H")
            minutes        = date.strftime("%M")

            # Calculate factors
            day_factor     = (int(day) / 31)
            year_factor    = (int(year) / 2018)
            month_factor   = (int(month) / 12)
            hours_factor   = (int(hours) / 24)  
            minutes_factor = (int(minutes) / 60)  
          
            features.append([year_factor, month_factor, day_factor, hours_factor, file, school_holiday, module])
            labels.append(amount_of_people);
            i += 1

        # Get timestamp each day
        # Receive hours between 08:00 - 17:00  
        now = dt.now()
        predict = ""

        # Split variables 
        for x in range(8,18):
            hours = x    
            year = now.strftime("%Y")
            month = now.strftime("%m")
            day   = now.strftime("%d")
            #hours  = now.strftime("%H")
            minutes = now.strftime("%M")

            # Generate day factors
            day_factor = (int(day) / 31)
            year_factor = (int(year) / 2018)
            month_factor = (int(month) / 12)
            hours_factor = (int(hours) / 24)

            # Check for file
            if (int(hours) >= 8 and int(hours)  <= 10) or (int(hours) == 18 or int(hours == 17)):
                file = 1
            else:
                file = 0
            strg = '{:%Y-%m-%d}'.format(now)

            # Check for school holiday by date
            response = requests.get("http://localhost:50798/api/suggestions/isholiday/" + strg)
            data_school_holiday = response.json() # get data

            # Call the tree classifier
            clf = tree.DecisionTreeClassifier()

            # Train the model
            clf = clf.fit(features,labels);

            # print("DEBUG : [hours] : " +  str(hours) + "year : "  + str(year_factor)  + " month : " + str(month_factor) + " day_factor : " + str(day_factor) + " hours_factor" + str(hours_factor) + " file " + str(file) + " holiday " + str(data_school_holiday) )
            # Generate suggestion
            suggestion = clf.predict([[year_factor,month_factor,day_factor,hours_factor,  file ,int(data_school_holiday) , 1]])
            predict +=str(suggestion) + ","
            #print(hours)
        
        print(predict)
        
GenerateSuggestion();
