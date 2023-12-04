þ
OC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject.Data\DataContext.cs
	namespace		 	
AssessmentProject		
 
.		 
Data		  
{

 
public 

class 
DataContext 
: 
	DbContext (
{ 
	protected 
override 
void 
OnConfiguring  -
(- .#
DbContextOptionsBuilder. E
optionsBuilderF T
)T U
{ 	
optionsBuilder 
. 
UseInMemoryDatabase .
(. /
$str/ @
)@ A
;A B
} 	
public 
DbSet 
< 
UserRepository #
># $
Users% *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
DbSet 
< 
InvoiceRepository &
>& '
Invoices( 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
public 
DbSet 
< 
StoreRepository $
>$ %
Stores& ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DbSet 
< 
DiscountRepository '
>' (
	Discounts) 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} …
]C:\Users\Eminf\Projects\AssessmentProject\AssessmentProject.Data\Domain\DiscountRepository.cs
	namespace		 	
AssessmentProject		
 
.		 
Data		  
.		  !
Domain		! '
{

 
public 

class 
DiscountRepository #
{ 
[ 	
Key	 
, 
DatabaseGenerated 
(  #
DatabaseGeneratedOption  7
.7 8
Identity8 @
)@ A
]A B
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
bool 
IsPercentageBased %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
decimal  
AppliedDiscountValue +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
InvoiceRepository  
?  !
Invoice" )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} Ä
\C:\Users\Eminf\Projects\AssessmentProject\AssessmentProject.Data\Domain\InvoiceRepository.cs
	namespace

 	
AssessmentProject


 
.

 
Data

  
.

  !
Domain

! '
{ 
public 

class 
InvoiceRepository "
{ 
[ 	
Key	 
, 
DatabaseGenerated 
(  #
DatabaseGeneratedOption  7
.7 8
Identity8 @
)@ A
]A B
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
decimal 
Cost 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 
	FinalCost  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
required 
DateTimeOffset &
InvoiceDate' 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
virtual 
ICollection "
<" #
DiscountRepository# 5
>5 6
?6 7
AppliedDiscounts8 H
{I J
getK N
;N O
setP S
;S T
}U V
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ý	
ZC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject.Data\Domain\StoreRepository.cs
	namespace		 	
AssessmentProject		
 
.		 
Data		  
.		  !
Domain		! '
{

 
public 

class 
StoreRepository  
{ 
[ 	
Key	 
, 
DatabaseGenerated 
(  #
DatabaseGeneratedOption  7
.7 8
Identity8 @
)@ A
]A B
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
required 
bool 
	IsGrocery &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
virtual 
ICollection "
<" #
UserRepository# 1
>1 2
?2 3
Users4 9
{: ;
get< ?
;? @
setA D
;D E
}F G
} 
} —
YC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject.Data\Domain\UserRepository.cs
	namespace		 	
AssessmentProject		
 
.		 
Data		  
.		  !
Domain		! '
{

 
public 

class 
UserRepository 
{ 
[ 	
Key	 
, 
DatabaseGenerated 
(  #
DatabaseGeneratedOption  7
.7 8
Identity8 @
)@ A
]A B
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
Surname 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
required 
bool 

IsEmployee '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
bool 
IsAffiliate (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
virtual 
ICollection "
<" #
InvoiceRepository# 4
>4 5
?5 6
Invoices7 ?
{@ A
getB E
;E F
setG J
;J K
}L M
public 
required 
StoreRepository '
Store( -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
} 