# luni
Library with key components for creating university schedule app

row format for tables:  
// FORBIDS usage of separators in strings  
(id optional) (; - column separator) (, - collection items separator)  
subject - id;name  
  
lesson - id;subjId;order;type;room where:  
  id - identifier  
  subjId - subject identifier  
  order - 1-8 int represents lesson order in overall schedule  
  type - 0-8 enum value  
    {  
      none = 0,  
      lecture = 1,  
      lab = 2,  
      practice = 3,  
      test = 4,  
      credit = 5,  
      consultation = 6,  
      exam = 7,  
      examRetake = 8,  
      lesson = 9  
    }  
  room - (max len 6) string room identirier like 303A or so.  
  
day - schedule for specific day in week  
>format id;dayOfWeek;lessonIds  
  id - identifier  
  dayOfWeek - 1-7 int  
  lessonIds - comma separated interger identifiers for connected lessons  
<
