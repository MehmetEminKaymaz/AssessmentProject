Ú
]C:\Users\Eminf\Projects\AssessmentProject\AssessmentProject\Controllers\DiscountController.cs
	namespace 	
AssessmentProject
 
. 
Api 
.  
Controllers  +
{ 
public 

class 
DiscountController #
{ 
} 
} Ø
]C:\Users\Eminf\Projects\AssessmentProject\AssessmentProject\Controllers\InvoicesController.cs
	namespace 	
AssessmentProject
 
. 
Api 
.  
Controllers  +
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
InvoicesController #
:$ %
ControllerBase& 4
{ 
private 
readonly '
CreateInvoiceCommandHandler 4(
_createInvoiceCommandHandler5 Q
;Q R
private 
readonly '
DeleteInvoiceCommandHandler 4(
_deleteInvoiceCommandHandler5 Q
;Q R
private 
readonly '
UpdateInvoiceCommandHandler 4(
_updateInvoiceCommandHandler5 Q
;Q R
private 
readonly "
GetInvoiceQueryHandler /#
_getInvoiceQueryHandler0 G
;G H
public 
InvoicesController !
(! "'
CreateInvoiceCommandHandler" ='
createInvoiceCommandHandler> Y
,Y Z'
DeleteInvoiceCommandHandler[ v(
deleteInvoiceCommandHandler	w ’
,
’ “)
UpdateInvoiceCommandHandler
” ¯)
updateInvoiceCommandHandler
° Ë
,
Ë Ì$
GetInvoiceQueryHandler
Í ã$
getInvoiceQueryHandler
ä ú
)
ú û
{ 	(
_createInvoiceCommandHandler (
=) *'
createInvoiceCommandHandler+ F
;F G(
_deleteInvoiceCommandHandler (
=) *'
deleteInvoiceCommandHandler+ F
;F G(
_updateInvoiceCommandHandler (
=) *'
updateInvoiceCommandHandler+ F
;F G#
_getInvoiceQueryHandler #
=$ %"
getInvoiceQueryHandler& <
;< =
} 	
[ 	
HttpPost	 
] 
public 
IActionResult 
Post !
(! " 
CreateInvoiceCommand" 6 
createInvoiceCommand7 K
)K L
{ 	
return 
Ok 
( (
_createInvoiceCommandHandler 2
.2 3
Handle3 9
(9 : 
createInvoiceCommand: N
)N O
)O P
;P Q
} 	
[   	

HttpDelete  	 
]   
public!! 
IActionResult!! 
Delete!! #
(!!# $ 
DeleteInvoiceCommand!!$ 8
command!!9 @
)!!@ A
{"" 	
return## 
Ok## 
(## (
_deleteInvoiceCommandHandler## 2
.##2 3
Handle##3 9
(##9 :
command##: A
)##A B
)##B C
;##C D
}$$ 	
[&& 	
HttpGet&&	 
]&& 
public'' 
IActionResult'' 
Get''  
(''  !

GetInvoice''! +
query'', 1
)''1 2
{(( 	
return)) 
Ok)) 
()) #
_getInvoiceQueryHandler)) -
.))- .
Handle)). 4
())4 5
query))5 :
))): ;
))); <
;))< =
}** 	
[,, 	
HttpPut,,	 
],, 
public-- 
IActionResult-- 
Put--  
(--  ! 
UpdateInvoiceCommand--! 5
command--6 =
)--= >
{.. 	
return// 
Ok// 
(// (
_updateInvoiceCommandHandler// 2
.//2 3
Handle//3 9
(//9 :
command//: A
)//A B
)//B C
;//C D
}00 	
}22 
}33 Ü
ZC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject\Controllers\StoreController.cs
	namespace 	
AssessmentProject
 
. 
Api 
.  
Controllers  +
{ 
public 

class 
StoreController  
:! "

Controller# -
{		 
private

 
readonly

 %
CreateStoreCommandHandler

 2&
_createStoreCommandHandler

3 M
;

M N
private 
readonly %
DeleteStoreCommandHandler 2&
_deleteStoreCommandHandler3 M
;M N
private 
readonly %
UpdateStoreCommandHandler 2&
_updateStoreCommandHandler3 M
;M N
private 
readonly  
GetStoreQueryHandler -!
_getStoreQueryHandler. C
;C D
public 
StoreController 
( %
CreateStoreCommandHandler 8%
createStoreCommandHandler9 R
,R S%
DeleteStoreCommandHandlerT m&
deleteStoreCommandHandler	n ‡
,
‡ ˆ'
UpdateStoreCommandHandler
‰ ¢'
updateStoreCommandHandler
£ ¼
,
¼ ½"
GetStoreQueryHandler
¾ Ò"
getStoreQueryHandler
Ó ç
)
ç è
{ 	&
_createStoreCommandHandler &
=' (%
createStoreCommandHandler) B
;B C&
_deleteStoreCommandHandler &
=' (%
deleteStoreCommandHandler) B
;B C&
_updateStoreCommandHandler &
=' (%
updateStoreCommandHandler) B
;B C!
_getStoreQueryHandler !
=" # 
getStoreQueryHandler$ 8
;8 9
} 	
[ 	
HttpPost	 
] 
public 
IActionResult 
Post !
(! "
CreateStoreCommand" 4
command5 <
)< =
{ 	
return 
Ok 
( &
_createStoreCommandHandler 0
.0 1
Handle1 7
(7 8
command8 ?
)? @
)@ A
;A B
} 	
[ 	

HttpDelete	 
] 
public 
IActionResult 
Delete #
(# $
DeleteStoreCommand$ 6
command7 >
)> ?
{ 	
return   
Ok   
(   &
_deleteStoreCommandHandler   0
.  0 1
Handle  1 7
(  7 8
command  8 ?
)  ? @
)  @ A
;  A B
}!! 	
[## 	
HttpGet##	 
]## 
public$$ 
IActionResult$$ 
Get$$  
($$  !
GetStoreQuery$$! .
query$$/ 4
)$$4 5
{%% 	
return&& 
Ok&& 
(&& !
_getStoreQueryHandler&& +
.&&+ ,
Handle&&, 2
(&&2 3
query&&3 8
)&&8 9
)&&9 :
;&&: ;
}'' 	
[)) 	
HttpPut))	 
])) 
public** 
IActionResult** 
Put**  
(**  !
UpdateStoreCommand**! 3
command**4 ;
)**; <
{++ 	
return,, 
Ok,, 
(,, &
_updateStoreCommandHandler,, 0
.,,0 1
Handle,,1 7
(,,7 8
command,,8 ?
),,? @
),,@ A
;,,A B
}-- 	
}.. 
}// ¹
YC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject\Controllers\UserController.cs
	namespace 	
AssessmentProject
 
. 
Api 
.  
Controllers  +
{ 
public 

class 
UserController 
:  !

Controller" ,
{		 
private

 
readonly

 $
CreateUserCommandHandler

 1%
_createUserCommandHandler

2 K
;

K L
private 
readonly $
DeleteUserCommandHandler 1%
_deleteUserCommandHandler2 K
;K L
private 
readonly $
UpdateUserCommandHandler 1%
_updateUserCommandHandler2 K
;K L
private 
readonly 
GetUserQueryHandler , 
_getUserQueryHandler- A
;A B
public 
UserController 
( $
CreateUserCommandHandler 6$
createUserCommandHandler7 O
,O P$
DeleteUserCommandHandlerQ i%
deleteUserCommandHandler	j ‚
,
‚ ƒ&
UpdateUserCommandHandler
„ œ&
updateUserCommandHandler
 µ
,
µ ¶!
GetUserQueryHandler
· Ê!
getUserQueryHandler
Ë Þ
)
Þ ß
{ 	%
_createUserCommandHandler %
=& '$
createUserCommandHandler( @
;@ A%
_deleteUserCommandHandler %
=& '$
deleteUserCommandHandler( @
;@ A%
_updateUserCommandHandler %
=& '$
updateUserCommandHandler( @
;@ A 
_getUserQueryHandler  
=! "
getUserQueryHandler# 6
;6 7
} 	
[ 	
HttpPost	 
] 
public 
IActionResult 
Post !
(! "
CreateUserCommand" 3
command4 ;
); <
{ 	
return 
Ok 
( %
_createUserCommandHandler /
./ 0
Handle0 6
(6 7
command7 >
)> ?
)? @
;@ A
} 	
[ 	

HttpDelete	 
] 
public 
IActionResult 
Delete #
(# $
DeleteUserCommand$ 5
command6 =
)= >
{ 	
return   
Ok   
(   %
_deleteUserCommandHandler   /
.  / 0
Handle  0 6
(  6 7
command  7 >
)  > ?
)  ? @
;  @ A
}!! 	
[## 	
HttpGet##	 
]## 
public$$ 
IActionResult$$ 
Get$$  
($$  !
GetUserQuery$$! -
query$$. 3
)$$3 4
{%% 	
return&& 
Ok&& 
(&&  
_getUserQueryHandler&& *
.&&* +
Handle&&+ 1
(&&1 2
query&&2 7
)&&7 8
)&&8 9
;&&9 :
}'' 	
[)) 	
HttpPut))	 
])) 
public** 
IActionResult** 
Put**  
(**  !
UpdateUserCommand**! 2
command**3 :
)**: ;
{++ 	
return,, 
Ok,, 
(,, %
_updateUserCommandHandler,, /
.,,/ 0
Handle,,0 6
(,,6 7
command,,7 >
),,> ?
),,? @
;,,@ A
}-- 	
}.. 
}// ð+
FC:\Users\Eminf\Projects\AssessmentProject\AssessmentProject\Program.cs
	namespace 	
AssessmentProject
 
. 
Api 
{ 
public		 

static		 
class		 
Program		 
{

 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
var 
builder 
= 
WebApplication (
.( )
CreateBuilder) 6
(6 7
args7 ;
); <
;< =
builder 
. 
Services 
. 
AddControllers +
(+ ,
), -
;- .
builder 
. 
Services 
. 
AddDbContext )
<) *
	DbContext* 3
,3 4
DataContext5 @
>@ A
(A B
)B C
;C D
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .'
CreateInvoiceCommandHandler. I
)I J
,J K
typeofL R
(R S'
CreateInvoiceCommandHandlerS n
)n o
)o p
;p q
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .'
UpdateInvoiceCommandHandler. I
)I J
,J K
typeofL R
(R S'
UpdateInvoiceCommandHandlerS n
)n o
)o p
;p q
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .'
DeleteInvoiceCommandHandler. I
)I J
,J K
typeofL R
(R S'
DeleteInvoiceCommandHandlerS n
)n o
)o p
;p q
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- ."
GetInvoiceQueryHandler. D
)D E
,E F
typeofG M
(M N"
GetInvoiceQueryHandlerN d
)d e
)e f
;f g
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .$
CreateUserCommandHandler. F
)F G
,G H
typeofI O
(O P$
CreateUserCommandHandlerP h
)h i
)i j
;j k
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .$
UpdateUserCommandHandler. F
)F G
,G H
typeofI O
(O P$
UpdateUserCommandHandlerP h
)h i
)i j
;j k
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .$
DeleteUserCommandHandler. F
)F G
,G H
typeofI O
(O P$
DeleteUserCommandHandlerP h
)h i
)i j
;j k
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .
GetUserQueryHandler. A
)A B
,B C
typeofD J
(J K
GetUserQueryHandlerK ^
)^ _
)_ `
;` a
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .%
CreateStoreCommandHandler. G
)G H
,H I
typeofJ P
(P Q%
CreateStoreCommandHandlerQ j
)j k
)k l
;l m
builder 
. 
Services 
. 
	AddScoped &
(& '
typeof' -
(- .%
UpdateStoreCommandHandler. G
)G H
,H I
typeofJ P
(P Q%
UpdateStoreCommandHandlerQ j
)j k
)k l
;l m
builder   
.   
Services   
.   
	AddScoped   &
(  & '
typeof  ' -
(  - .%
DeleteStoreCommandHandler  . G
)  G H
,  H I
typeof  J P
(  P Q%
DeleteStoreCommandHandler  Q j
)  j k
)  k l
;  l m
builder!! 
.!! 
Services!! 
.!! 
	AddScoped!! &
(!!& '
typeof!!' -
(!!- . 
GetStoreQueryHandler!!. B
)!!B C
,!!C D
typeof!!E K
(!!K L 
GetStoreQueryHandler!!L `
)!!` a
)!!a b
;!!b c
var## 
app## 
=## 
builder## 
.## 
Build## #
(### $
)##$ %
;##% &
app'' 
.'' 
UseHttpsRedirection'' #
(''# $
)''$ %
;''% &
app)) 
.)) 
UseAuthorization))  
())  !
)))! "
;))" #
app,, 
.,, 
MapControllers,, 
(,, 
),,  
;,,  !
app.. 
... 
Run.. 
(.. 
).. 
;.. 
}// 	
}00 
}11 