Œ
JC:\Users\Eminf\Projects\AssessmentProject\Application\BaseResponseModel.cs
	namespace 	
AssessmentProject
 
. 
Application '
{ 
public		 

class		 
BaseResponseModel		 "
<		" #
T		# $
>		$ %
{

 
public 
long 
Total 
{ 
get 
;  
set! $
;$ %
}& '
public 
bool 
Status 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
? 
Message 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
T 
? 
Data 
{ 
get 
; 
set !
;! "
}# $
} 
} Ê&
SC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\AffiliateDiscount.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Discount

( 0
{ 
public 

sealed 
class 
AffiliateDiscount )
:* +
Discount, 4
{ 
private 
readonly 
DataContext $
_context% -
;- .
public 
AffiliateDiscount  
(  !
DataContext! ,
context- 4
,4 5
string5 ;
name< @
=A B
$strC W
,W X
stringY _
description` k
=l m
$str	n ó
)
ó ò
:
ô ö
base
õ ü
(
ü †
context
† ß
)
ß ®
{ 	
this 
. 
Name 
= 
name 
; 
this 
. 
Description 
= 
description *
;* +
this 
. 
IsPercentageBased "
=# $
true% )
;) *
_context 
= 
context 
; 
} 	
public 
override 
bool 
ApplyDiscount *
(* +
InvoiceRepository+ <
invoice= D
)D E
{ 	
if 
( 
! 
IsApplicable 
( 
invoice %
)% &
)& '
{ 
return 
false 
; 
} 
this 
.  
AppliedDiscountValue %
=& '
(( )
invoice) 0
.0 1
	FinalCost1 :
*; <
$num= ?
)? @
/A B
$numC F
;F G
var 
affiliateDiscount !
=" #
new$ '
DiscountRepository( :
(: ;
); <
{   
IsPercentageBased!! !
=!!" #
this!!$ (
.!!( )
IsPercentageBased!!) :
,!!: ; 
AppliedDiscountValue"" $
=""% &
(""' (
invoice""( /
.""/ 0
	FinalCost""0 9
*"": ;
$num""< >
)""> ?
/""@ A
$num""B E
,""E F
Description## 
=## 
this## "
.##" #
Description### .
,##. /
Name$$ 
=$$ 
this$$ 
.$$ 
Name$$  
,$$  !
Invoice%% 
=%% 
invoice%% !
}&& 
;&& 
invoice'' 
.'' 
AppliedDiscounts'' $
??=''% (
new'') ,
List''- 1
<''1 2
DiscountRepository''2 D
>''D E
(''E F
)''F G
;''G H
invoice(( 
.(( 
AppliedDiscounts(( $
.(($ %
Add((% (
(((( )
affiliateDiscount(() :
)((: ;
;((; <
_context)) 
.)) 
SaveChanges))  
())  !
)))! "
;))" #
return++ 
true++ 
;++ 
},, 	
public.. 
override.. 
bool.. 
IsApplicable.. )
(..) *
InvoiceRepository..* ;
invoice..< C
)..C D
{// 	
if00 
(00 
!00 
CheckForStaticRules00 $
(00$ %
invoice00% ,
)00, -
||00. 0
!001 2
this002 6
.006 7
CheckDiscount007 D
(00D E
invoice00E L
)00L M
)00M N
{11 
return22 
false22 
;22 
}33 
return55 
true55 
;55 
}66 	
public88 
override88 
bool88 
CheckDiscount88 *
(88* +
InvoiceRepository88+ <
invoice88= D
)88D E
{99 	
var:: 
user:: 
=:: 
_context:: 
.::  
Users::  %
.::% &
FirstOrDefault::& 4
(::4 5
u::5 6
=>::7 9
u::: ;
.::; <
Id::< >
==::? A
invoice::B I
.::I J
UserId::J P
)::P Q
;::Q R
if;; 
(;; 
user;; 
==;; 
null;; 
);; 
{<< 
return== 
false== 
;== 
}>> 
if@@ 
(@@ 
!@@ 
user@@ 
.@@ 
IsAffiliate@@ !
)@@! "
{AA 
returnBB 
falseBB 
;BB 
}CC 
returnEE 
trueEE 
;EE 
}FF 	
}GG 
}HH ¸
VC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\BulkPurchaseDiscount.cs
	namespace		 	
AssessmentProject		
 
.		 
Application		 '
.		' (
Discount		( 0
{

 
public 

sealed 
class  
BulkPurchaseDiscount ,
:- .
Discount/ 7
{ 
private 
readonly 
DataContext $
_context% -
;- .
public  
BulkPurchaseDiscount #
(# $
DataContext$ /
context0 7
,7 8
string9 ?
name@ D
=E F
$strG ^
,^ _
string` f
descriptiong r
=s t
$str	u ë
)
ë í
:
ì î
base
ï ô
(
ô ö
context
ö °
)
° ¢
{ 	
_context 
= 
context 
; 
this 
. 
Name 
= 
name 
; 
this 
. 
Description 
= 
description *
;* +
} 	
public 
override 
bool 
ApplyDiscount *
(* +
InvoiceRepository+ <
invoice= D
)D E
{ 	
if 
( 
! 
IsApplicable 
( 
invoice %
)% &
)& '
{ 
return 
false 
; 
} 
this 
.  
AppliedDiscountValue %
=& '
(( )
invoice) 0
.0 1
	FinalCost1 :
/; <
$num= @
)@ A
*B C
$numD E
;E F
var 
bulkDiscount 
= 
new "
DiscountRepository# 5
(5 6
)6 7
{ 
IsPercentageBased   !
=  " #
this  $ (
.  ( )
IsPercentageBased  ) :
,  : ; 
AppliedDiscountValue!! $
=!!% &
(!!' (
invoice!!( /
.!!/ 0
	FinalCost!!0 9
/!!: ;
$num!!< ?
)!!? @
*!!A B
$num!!C D
,!!D E
Description"" 
="" 
this"" "
.""" #
Description""# .
,"". /
Name## 
=## 
this## 
.## 
Name##  
,##  !
Invoice$$ 
=$$ 
invoice$$ !
}%% 
;%% 
invoice&& 
.&& 
AppliedDiscounts&& $
??=&&% (
new&&) ,
List&&- 1
<&&1 2
DiscountRepository&&2 D
>&&D E
(&&E F
)&&F G
;&&G H
invoice'' 
.'' 
AppliedDiscounts'' $
.''$ %
Add''% (
(''( )
bulkDiscount'') 5
)''5 6
;''6 7
_context(( 
.(( 
SaveChanges((  
(((  !
)((! "
;((" #
return** 
true** 
;** 
}++ 	
public,, 
override,, 
bool,, 
IsApplicable,, )
(,,) *
InvoiceRepository,,* ;
invoice,,< C
),,C D
{-- 	
if.. 
(.. 
!.. 
CheckForStaticRules.. $
(..$ %
invoice..% ,
).., -
||... 0
!..1 2
CheckDiscount..2 ?
(..? @
invoice..@ G
)..G H
)..H I
{// 
return00 
false00 
;00 
}11 
return33 
true33 
;33 
}44 	
public66 
override66 
bool66 
CheckDiscount66 *
(66* +
InvoiceRepository66+ <
invoice66= D
)66D E
{77 	
return88 
true88 
;88 
}99 	
}:: 
};; „
`C:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Commands\CreateDiscountCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
.0 1
Commands1 9
{ 
public 

class !
CreateDiscountCommand &
{ 
public 
int 

DiscountId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
Guid		 
AppliedDiscountId		 %
{		& '
get		( +
;		+ ,
set		- 0
;		0 1
}		2 3
}

 
} ¡
`C:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Commands\DeleteDiscountCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
.0 1
Commands1 9
{ 
public 

class !
DeleteDiscountCommand &
{ 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 

DiscountId 
{  
get! $
;$ %
set& )
;) *
}* +
}		 
}

 Ù!
JC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Discount.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Discount

( 0
{ 
public 

class 
Discount 
: 
	IDiscount %
{ 
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
}2 3
=4 5
false6 ;
;; <
public 
decimal  
AppliedDiscountValue +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
=: ;
$num< >
;> ?
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
private 
readonly 
DataContext $
_context% -
;- .
public 
Discount 
( 
DataContext #
context$ +
)+ ,
{ 	
_context 
= 
context 
; 
} 	
public 
virtual 
bool 
ApplyDiscount )
() *
InvoiceRepository* ;
invoice< C
)C D
{ 	
throw 
new #
NotImplementedException -
(- .
). /
;/ 0
} 	
public 
virtual 
bool 
CheckDiscount )
() *
InvoiceRepository* ;
invoice< C
)C D
{   	
throw!! 
new!! #
NotImplementedException!! -
(!!- .
)!!. /
;!!/ 0
}"" 	
public$$ 
virtual$$ 
bool$$ 
IsApplicable$$ (
($$( )
InvoiceRepository$$) :
invoice$$; B
)$$B C
{%% 	
throw&& 
new&& #
NotImplementedException&& -
(&&- .
)&&. /
;&&/ 0
}'' 	
public)) 
bool)) 
CheckForStaticRules)) '
())' (
InvoiceRepository))( 9
invoice)): A
)))A B
{** 	
var++ 
user++ 
=++ 
_context++ 
.++  
Users++  %
.++% &
Include++& -
(++- .
userRepository++. <
=>++= ?
userRepository++@ N
.++N O
Store++O T
)++T U
.++U V
FirstOrDefault++V d
(++d e
u++e f
=>++g i
u++j k
.++k l
Id++l n
==++o q
invoice++r y
.++y z
UserId	++z Ä
)
++Ä Å
;
++Å Ç
if,, 
(,, 
user,, 
==,, 
null,, 
),, 
{-- 
return.. 
false.. 
;.. 
}// 
if11 
(11 
this11 
.11 
IsPercentageBased11 &
&&11' )
user11* .
.11. /
Store11/ 4
.114 5
	IsGrocery115 >
)11> ?
{22 
return33 
false33 
;33 
}44 
if66 
(66 
invoice66 
.66 
AppliedDiscounts66 (
!=66) +
null66, 0
&&661 3
this664 8
.668 9
IsPercentageBased669 J
&&66K M
invoice66N U
.66U V
AppliedDiscounts66V f
.66f g
Any66g j
(66j k
d66k l
=>66m o
d66p q
.66q r
IsPercentageBased	66r É
)
66É Ñ
)
66Ñ Ö
{77 
return88 
false88 
;88 
}99 
return;; 
true;; 
;;; 
}<< 	
}== 
}>> Â
NC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\DiscountEnum.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
{		 
public

 

class

 
DiscountEnum

 
{ 
public 
enum 
DiscountType  
{ 	
AffiliateDiscount 
= 
$num  !
,! "
EmployeeDiscount 
= 
$num  
,  ! 
BulkPurchaseDiscount  
=! "
$num# $
,$ %
LongTimeDiscount 
= 
$num  
,  !
} 	
} 
} ø&
RC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\EmployeeDiscount.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Discount

( 0
{ 
public 

sealed 
class 
EmployeeDiscount (
:) *
Discount+ 3
{ 
private 
readonly 
DataContext $
_context% -
;- .
public 
EmployeeDiscount 
(  
DataContext  +
context, 3
,3 4
string5 ;
name< @
=A B
$strC V
,V W
stringX ^
description_ j
=k l
$str	m ï
)
ï ñ
:
ó ò
base
ô ù
(
ù û
context
û •
)
• ¶
{ 	
_context 
= 
context 
; 
this 
. 
Name 
= 
name 
; 
this 
. 
Description 
= 
description *
;* +
this 
. 
IsPercentageBased "
=# $
true% )
;) *
} 	
public 
override 
bool 
ApplyDiscount *
(* +
InvoiceRepository+ <
invoice= D
)D E
{ 	
if 
( 
! 
IsApplicable 
( 
invoice %
)% &
)& '
{ 
return 
false 
; 
} 
this 
.  
AppliedDiscountValue %
=& '
(( )
invoice) 0
.0 1
	FinalCost1 :
*; <
$num= ?
)? @
/A B
$numC F
;F G
var 
employeeDiscount  
=! "
new# &
DiscountRepository' 9
(9 :
): ;
{   
IsPercentageBased!! !
=!!" #
this!!$ (
.!!( )
IsPercentageBased!!) :
,!!: ; 
AppliedDiscountValue"" $
=""% &
(""' (
invoice""( /
.""/ 0
	FinalCost""0 9
*"": ;
$num""< >
)""> ?
/""@ A
$num""B E
,""E F
Description## 
=## 
this## "
.##" #
Description### .
,##. /
Name$$ 
=$$ 
this$$ 
.$$ 
Name$$  
,$$  !
Invoice%% 
=%% 
invoice%% !
}&& 
;&& 
invoice'' 
.'' 
AppliedDiscounts'' $
??=''% (
new'') ,
List''- 1
<''1 2
DiscountRepository''2 D
>''D E
(''E F
)''F G
;''G H
invoice(( 
.(( 
AppliedDiscounts(( $
.(($ %
Add((% (
(((( )
employeeDiscount(() 9
)((9 :
;((: ;
_context)) 
.)) 
SaveChanges))  
())  !
)))! "
;))" #
return** 
true** 
;** 
}++ 	
public-- 
override-- 
bool-- 
IsApplicable-- )
(--) *
InvoiceRepository--* ;
invoice--< C
)--C D
{.. 	
if// 
(// 
!// 
CheckForStaticRules// $
(//$ %
invoice//% ,
)//, -
||//. 0
!//1 2
CheckDiscount//2 ?
(//? @
invoice//@ G
)//G H
)//H I
{00 
return11 
false11 
;11 
}22 
return44 
true44 
;44 
}55 	
public77 
override77 
bool77 
CheckDiscount77 *
(77* +
InvoiceRepository77+ <
invoice77= D
)77D E
{88 	
var99 
user99 
=99 
_context99 
.99  
Users99  %
.99% &
FirstOrDefault99& 4
(994 5
u995 6
=>997 9
u99: ;
.99; <
Id99< >
==99? A
invoice99B I
.99I J
UserId99J P
)99P Q
;99Q R
if:: 
(:: 
user:: 
==:: 
null:: 
):: 
{;; 
return<< 
false<< 
;<< 
}== 
if?? 
(?? 
!?? 
user?? 
.?? 

IsEmployee??  
)??  !
{@@ 
returnAA 
falseAA 
;AA 
}BB 
returnDD 
trueDD 
;DD 
}EE 	
}FF 
}GG È2
fC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Handler\CreateDiscountCommandHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
.0 1
Handler1 8
{ 
public 

class (
CreateDiscountCommandHandler -
{ 
private		 
readonly		 
DataContext		 $
_context		% -
;		- .
public

 (
CreateDiscountCommandHandler

 +
(

+ ,
DataContext

, 7
context

8 ?
)

? @
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !!
CreateDiscountCommand! 6
>6 7
Handle8 >
(> ?!
CreateDiscountCommand? T
commandU \
)\ ]
{ 	
var #
invoiceWillBeDiscounted '
=( )
_context* 2
.2 3
Invoices3 ;
. 
Include 
( 
invoiceRepository *
=>+ -
invoiceRepository. ?
.? @
AppliedDiscounts@ P
)P Q
.Q R
FirstOrDefaultR `
(` a
ia b
=>c e
if g
.g h
Idh j
==k m
commandn u
.u v
	InvoiceIdv 
)	 Ä
;
Ä Å
if 
( #
invoiceWillBeDiscounted '
==( *
null+ /
)/ 0
{ 
return 
new 
BaseResponseModel ,
<, -!
CreateDiscountCommand- B
>B C
(C D
)D E
{ 
Status 
= 
false "
," #
} 
; 
} 
var 
discountResult 
=  
false! &
;& '
switch 
( 
command 
. 

DiscountId &
)& '
{ 
case   
(   
int   
)   
DiscountEnum   &
.  & '
DiscountType  ' 3
.  3 4
AffiliateDiscount  4 E
:  E F
var!! 
affiliateDiscount!! )
=!!* +
new!!, /
AffiliateDiscount!!0 A
(!!A B
_context!!B J
)!!J K
;!!K L
discountResult"" "
=""# $
affiliateDiscount""% 6
.""6 7
ApplyDiscount""7 D
(""D E#
invoiceWillBeDiscounted""E \
)""\ ]
;""] ^
break## 
;## 
case$$ 
($$ 
int$$ 
)$$ 
DiscountEnum$$ &
.$$& '
DiscountType$$' 3
.$$3 4
EmployeeDiscount$$4 D
:$$D E
var%% 
employeeDiscount%% (
=%%) *
new%%+ .
EmployeeDiscount%%/ ?
(%%? @
_context%%@ H
)%%H I
;%%I J
discountResult&& "
=&&# $
employeeDiscount&&% 5
.&&5 6
ApplyDiscount&&6 C
(&&C D#
invoiceWillBeDiscounted&&D [
)&&[ \
;&&\ ]
break'' 
;'' 
case(( 
((( 
int(( 
)(( 
DiscountEnum(( &
.((& '
DiscountType((' 3
.((3 4 
BulkPurchaseDiscount((4 H
:((H I
var))  
bulkPurchaseDiscount)) ,
=))- .
new))/ 2 
BulkPurchaseDiscount))3 G
())G H
_context))H P
)))P Q
;))Q R
discountResult** "
=**# $ 
bulkPurchaseDiscount**% 9
.**9 :
ApplyDiscount**: G
(**G H#
invoiceWillBeDiscounted**H _
)**_ `
;**` a
break++ 
;++ 
case,, 
(,, 
int,, 
),, 
DiscountEnum,, &
.,,& '
DiscountType,,' 3
.,,3 4
LongTimeDiscount,,4 D
:,,D E
var-- 
longTimeDiscount-- (
=--) *
new--+ .
LongTimeDiscount--/ ?
(--? @
_context--@ H
)--H I
;--I J
discountResult.. "
=..# $
longTimeDiscount..% 5
...5 6
ApplyDiscount..6 C
(..C D#
invoiceWillBeDiscounted..D [
)..[ \
;..\ ]
break// 
;// 
}00 
Guid11 
?11 
appliedDiscount11 !
=11" #
Guid11$ (
.11( )
Empty11) .
;11. /
if33 
(33 #
invoiceWillBeDiscounted33 '
is33( *
{33+ ,
AppliedDiscounts33- =
:33= >
not33? B
null33C G
}33H I
)33I J
{44 
appliedDiscount55 
=55  !#
invoiceWillBeDiscounted55" 9
.559 :
AppliedDiscounts55: J
.55J K
LastOrDefault55K X
(55X Y
)55Y Z
?55Z [
.55[ \
Id55\ ^
;55^ _
}66 
if88 
(88 
!88 
discountResult88 
)88  
{99 
return:: 
new:: 
BaseResponseModel:: ,
<::, -!
CreateDiscountCommand::- B
>::B C
(::C D
)::D E
{;; 
Status<< 
=<< 
false<< "
,<<" #
}== 
;== 
}>> 
return@@ 
new@@ 
BaseResponseModel@@ (
<@@( )!
CreateDiscountCommand@@) >
>@@> ?
(@@? @
)@@@ A
{AA 
DataBB 
=BB 
newBB !
CreateDiscountCommandBB 0
(BB0 1
)BB1 2
{CC 
	InvoiceIdDD 
=DD #
invoiceWillBeDiscountedDD  7
.DD7 8
IdDD8 :
,DD: ;

DiscountIdEE 
=EE  
commandEE! (
.EE( )

DiscountIdEE) 3
,EE3 4
AppliedDiscountIdFF %
=FF& '
appliedDiscountFF( 7
??FF8 :
GuidFF; ?
.FF? @
EmptyFF@ E
,FFE F
}GG 
,GG 
StatusHH 
=HH 
trueHH 
,HH 
}II 
;II 
}JJ 	
}KK 
}LL Î
fC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Handler\DeleteDiscountCommandHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
.0 1
Handler1 8
{ 
public 

class (
DeleteDiscountCommandHandler -
{ 
private		 
readonly		 
DataContext		 $
_context		% -
;		- .
public

 (
DeleteDiscountCommandHandler

 +
(

+ ,
DataContext

, 7
context

8 ?
)

? @
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !!
DeleteDiscountCommand! 6
>6 7
Handle8 >
(> ?!
DeleteDiscountCommand? T
commandU \
)\ ]
{ 	
var 
invoice 
= 
_context "
." #
Invoices# +
.+ ,
Include, 3
(3 4
invoiceRepository4 E
=>F H
invoiceRepositoryI Z
.Z [
AppliedDiscounts[ k
)k l
.l m
FirstOrDefaultm {
({ |
i| }
=>	~ Ä
i
Å Ç
.
Ç É
Id
É Ö
==
Ü à
command
â ê
.
ê ë
	InvoiceId
ë ö
)
ö õ
;
õ ú
if 
( 
invoice 
== 
null 
||  "
invoice# *
.* +
AppliedDiscounts+ ;
==< >
null? C
)C D
{ 
return 
new 
BaseResponseModel ,
<, -!
DeleteDiscountCommand- B
>B C
(C D
)D E
{ 
Status 
= 
false "
," #
} 
; 
} 
var 
appliedDiscount 
=  !
invoice" )
.) *
AppliedDiscounts* :
.: ;
FirstOrDefault; I
(I J
dJ K
=>L N
dO P
.P Q
IdQ S
==T V
commandW ^
.^ _

DiscountId_ i
)i j
;j k
if 
( 
appliedDiscount 
==  "
null# '
)' (
{ 
return 
new 
BaseResponseModel ,
<, -!
DeleteDiscountCommand- B
>B C
(C D
)D E
{ 
Status   
=   
false   "
,  " #
}!! 
;!! 
}"" 
invoice$$ 
.$$ 
	FinalCost$$ 
+=$$  
appliedDiscount$$! 0
.$$0 1 
AppliedDiscountValue$$1 E
;$$E F
invoice%% 
.%% 
AppliedDiscounts%% $
.%%$ %
Remove%%% +
(%%+ ,
appliedDiscount%%, ;
)%%; <
;%%< =
_context&& 
.&& 
SaveChanges&&  
(&&  !
)&&! "
;&&" #
return(( 
new(( 
BaseResponseModel(( (
<((( )!
DeleteDiscountCommand(() >
>((> ?
(((? @
)((@ A
{((B C
Status((D J
=((K L
true((M Q
,((Q R
Data((S W
=((X Y
new((Z ]!
DeleteDiscountCommand((^ s
(((s t
)((t u
{)) 

DiscountId** 
=** 
appliedDiscount** ,
.**, -
Id**- /
,**/ 0
	InvoiceId++ 
=++ 
invoice++ #
.++# $
Id++$ &
},, 
},, 
;,, 
}-- 	
}.. 
}// ˝-
aC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Handler\GetDiscountQueryHandler.cs
	namespace		 	
AssessmentProject		
 
.		 
Application		 '
.		' (
Discount		( 0
.		0 1
Handler		1 8
{

 
public 

class #
GetDiscountQueryHandler (
{ 
private 
readonly 
DataContext $
_context% -
;- .
public #
GetDiscountQueryHandler &
(& '
DataContext' 2
context3 :
): ;
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !
GetDiscountQuery! 1
>1 2
Handle3 9
(9 :
GetDiscountQuery: J
queryK P
)P Q
{ 	
var #
invoiceWillBeDiscounted '
=( )
_context* 2
.2 3
Invoices3 ;
.; <
FirstOrDefault< J
(J K
iK L
=>M O
iP Q
.Q R
IdR T
==U W
queryX ]
.] ^
	InvoiceId^ g
)g h
;h i
if 
( #
invoiceWillBeDiscounted '
==( *
null+ /
)/ 0
{ 
return 
new 
BaseResponseModel ,
<, -
GetDiscountQuery- =
>= >
(> ?
)? @
{ 
Status 
= 
false "
," #
} 
; 
} 
var 
user 
= 
_context 
.  
Users  %
.% &
FirstOrDefault& 4
(4 5
u5 6
=>7 9
u: ;
.; <
Id< >
==? A#
invoiceWillBeDiscountedB Y
.Y Z
UserIdZ `
)` a
;a b
if   
(   
user   
==   
null   
)   
{!! 
return"" 
new"" 
BaseResponseModel"" ,
<"", -
GetDiscountQuery""- =
>""= >
(""> ?
)""? @
{## 
Status$$ 
=$$ 
false$$ "
,$$" #
}%% 
;%% 
}&& 
var(( 
affiliateDiscount(( !
=((" #
new(($ '
AffiliateDiscount((( 9
(((9 :
_context((: B
)((B C
;((C D
var)) 
employeeDiscount))  
=))! "
new))# &
EmployeeDiscount))' 7
())7 8
_context))8 @
)))@ A
;))A B
var** 
longTimeDiscount**  
=**! "
new**# &
LongTimeDiscount**' 7
(**7 8
_context**8 @
)**@ A
;**A B
var++ 
bulkDiscount++ 
=++ 
new++ " 
BulkPurchaseDiscount++# 7
(++7 8
_context++8 @
)++@ A
;++A B
var-- !
availableDiscountList-- %
=--& '
new--( +
List--, 0
<--0 1
int--1 4
>--4 5
(--5 6
)--6 7
;--7 8
if.. 
(.. 
affiliateDiscount.. !
...! "
IsApplicable.." .
(... /#
invoiceWillBeDiscounted../ F
)..F G
)..G H
{// !
availableDiscountList00 %
.00% &
Add00& )
(00) *
(00* +
int00+ .
)00. /
DiscountEnum00/ ;
.00; <
DiscountType00< H
.00H I
AffiliateDiscount00I Z
)00Z [
;00[ \
}11 
if33 
(33 
employeeDiscount33  
.33  !
IsApplicable33! -
(33- .#
invoiceWillBeDiscounted33. E
)33E F
)33F G
{44 !
availableDiscountList55 %
.55% &
Add55& )
(55) *
(55* +
int55+ .
)55. /
DiscountEnum55/ ;
.55; <
DiscountType55< H
.55H I
EmployeeDiscount55I Y
)55Y Z
;55Z [
}66 
if88 
(88 
longTimeDiscount88  
.88  !
IsApplicable88! -
(88- .#
invoiceWillBeDiscounted88. E
)88E F
)88F G
{99 !
availableDiscountList:: %
.::% &
Add::& )
(::) *
(::* +
int::+ .
)::. /
DiscountEnum::/ ;
.::; <
DiscountType::< H
.::H I
LongTimeDiscount::I Y
)::Y Z
;::Z [
};; 
if== 
(== 
bulkDiscount== 
.== 
IsApplicable== )
(==) *#
invoiceWillBeDiscounted==* A
)==A B
)==B C
{>> !
availableDiscountList?? %
.??% &
Add??& )
(??) *
(??* +
int??+ .
)??. /
DiscountEnum??/ ;
.??; <
DiscountType??< H
.??H I 
BulkPurchaseDiscount??I ]
)??] ^
;??^ _
}@@ 
queryBB 
.BB  
AvailableDiscountIdsBB &
=BB' (!
availableDiscountListBB) >
.BB> ?
ToArrayBB? F
(BBF G
)BBG H
;BBH I
returnFF 
newFF 
BaseResponseModelFF (
<FF( )
GetDiscountQueryFF) 9
>FF9 :
(FF: ;
)FF; <
{GG 
StatusHH 
=HH 
trueHH 
,HH 
DataII 
=II 
queryII 
}JJ 
;JJ 
}KK 	
}LL 
}MM Ò
KC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\IDiscount.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
{		 
public

 

	interface

 
	IDiscount

 
{ 
bool 
ApplyDiscount 
( 
InvoiceRepository ,
invoice- 4
)4 5
;5 6
bool 
CheckDiscount 
( 
InvoiceRepository ,
invoice- 4
)4 5
;5 6
bool 
IsApplicable 
( 
InvoiceRepository +
invoice, 3
)3 4
;4 5
} 
} »+
RC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\LongTimeDiscount.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
{ 
public 

sealed 
class 
LongTimeDiscount (
:) *
Discount+ 3
{ 
private 
readonly 
DataContext $
_context% -
;- .
public 
LongTimeDiscount 
(  
DataContext  +
context, 3
,3 4
string5 ;
name< @
=A B
$strC V
,V W
stringX ^
description_ j
=k l
$str	m ã
)
ã å
:
ç é
base
è ì
(
ì î
context
î õ
)
õ ú
{ 	
_context 
= 
context 
; 
this 
. 
Name 
= 
name 
; 
this 
. 
Description 
= 
description *
;* +
this 
. 
IsPercentageBased "
=# $
true% )
;) *
} 	
public 
override 
bool 
ApplyDiscount *
(* +
InvoiceRepository+ <
invoice= D
)D E
{ 	
if 
( 
! 
IsApplicable 
( 
invoice %
)% &
)& '
{ 
return 
false 
; 
} 
this 
.  
AppliedDiscountValue %
=& '
(( )
invoice) 0
.0 1
	FinalCost1 :
*; <
$num= >
)> ?
/@ A
$numB E
;E F
var   
longTimeDiscount    
=  ! "
new  # &
DiscountRepository  ' 9
(  9 :
)  : ;
{!! 
IsPercentageBased"" !
=""" #
this""$ (
.""( )
IsPercentageBased"") :
,"": ; 
AppliedDiscountValue## $
=##% &
(##' (
invoice##( /
.##/ 0
	FinalCost##0 9
*##: ;
$num##< =
)##= >
/##? @
$num##A D
,##D E
Description$$ 
=$$ 
this$$ "
.$$" #
Description$$# .
,$$. /
Name%% 
=%% 
this%% 
.%% 
Name%%  
,%%  !
Invoice&& 
=&& 
invoice&& !
}'' 
;'' 
invoice(( 
.(( 
AppliedDiscounts(( $
??=((% (
new(() ,
List((- 1
<((1 2
DiscountRepository((2 D
>((D E
(((E F
)((F G
;((G H
invoice)) 
.)) 
AppliedDiscounts)) $
.))$ %
Add))% (
())( )
longTimeDiscount))) 9
)))9 :
;)): ;
_context** 
.** 
SaveChanges**  
(**  !
)**! "
;**" #
return++ 
true++ 
;++ 
},, 	
public-- 
override-- 
bool-- 
IsApplicable-- )
(--) *
InvoiceRepository--* ;
invoice--< C
)--C D
{.. 	
if// 
(// 
!// 
CheckForStaticRules// $
(//$ %
invoice//% ,
)//, -
||//. 0
!//1 2
CheckDiscount//2 ?
(//? @
invoice//@ G
)//G H
)//H I
{00 
return11 
false11 
;11 
}22 
return44 
true44 
;44 
}55 	
public77 
override77 
bool77 
CheckDiscount77 *
(77* +
InvoiceRepository77+ <
invoice77= D
)77D E
{88 	
var99 
user99 
=99 
_context99 
.99  
Users99  %
.99% &
Include99& -
(99- .
userRepository99. <
=>99= ?
userRepository99@ N
.99N O
Invoices99O W
)99W X
.99X Y
FirstOrDefault99Y g
(99g h
u99h i
=>99j l
u99m n
.99n o
Id99o q
==99r t
invoice99u |
.99| }
UserId	99} É
)
99É Ñ
;
99Ñ Ö
if:: 
(:: 
user:: 
==:: 
null:: 
):: 
{;; 
return<< 
false<< 
;<< 
}== 
if?? 
(?? 
user?? 
.?? 
Invoices?? 
!=??  
null??! %
&&??& (
user??) -
.??- .
Invoices??. 6
.??6 7
MinBy??7 <
(??< =
i??= >
=>??? A
i??B C
.??C D
InvoiceDate??D O
)??O P
!??P Q
.??Q R
InvoiceDate??R ]
>??^ _
DateTimeOffset??` n
.??n o
Now??o r
.??r s
AddYears??s {
(??{ |
-??| }
$num??} ~
)??~ 
)	?? Ä
{@@ 
returnAA 
falseAA 
;AA 
}BB 
returnDD 
trueDD 
;DD 
}EE 	
}FF 
}GG ‹
ZC:\Users\Eminf\Projects\AssessmentProject\Application\Discount\Queries\GetDiscountQuery.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Discount( 0
.0 1
Queries1 8
{ 
public		 

class		 
GetDiscountQuery		 !
{

 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
[ 
]  
AvailableDiscountIds )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} ¶	
^C:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Commands\CreateInvoiceCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Invoice( /
./ 0
Commands0 8
{ 
public		 

class		  
CreateInvoiceCommand		 %
{

 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
decimal 
Cost 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 
	FinalCost  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
required 
DateTimeOffset &
InvoiceDate' 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} °
^C:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Commands\DeleteInvoiceCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Invoice( /
./ 0
Commands0 8
{ 
public		 

class		  
DeleteInvoiceCommand		 %
{

 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ï
^C:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Commands\UpdateInvoiceCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Invoice( /
./ 0
Commands0 8
{ 
public		 

class		  
UpdateInvoiceCommand		 %
{

 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
decimal 
Cost 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 
	FinalCost  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
required 
DateTimeOffset &
InvoiceDate' 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
} 
} è
dC:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Handler\CreateInvoiceCommandHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Invoice( /
./ 0
Handler0 7
{ 
public 

class '
CreateInvoiceCommandHandler ,
{ 
private		 
readonly		 
DataContext		 $
_context		% -
;		- .
public

 '
CreateInvoiceCommandHandler

 *
(

* +
DataContext

+ 6
context

7 >
)

> ?
=>

@ B
_context

C K
=

L M
context

N U
;

U V
public 
BaseResponseModel  
<  ! 
CreateInvoiceCommand! 5
>5 6
Handle7 =
(= > 
CreateInvoiceCommand> R
commandS Z
)Z [
{ 	
var 
user 
= 
_context 
.  
Users  %
.% &
FirstOrDefault& 4
(4 5
u5 6
=>7 9
u: ;
.; <
Id< >
==? A
commandB I
.I J
UserIdJ P
)P Q
;Q R
if 
( 
user 
== 
null 
) 
{ 
return 
new 
BaseResponseModel ,
<, - 
CreateInvoiceCommand- A
>A B
(B C
)C D
{ 
Status 
= 
false "
} 
; 
} 
var 
createdInvoice 
=  
new! $
InvoiceRepository% 6
(6 7
)7 8
{ 
InvoiceDate 
= 
DateTimeOffset ,
., -
Now- 0
,0 1
UserId 
= 
user 
. 
Id  
,  !
	FinalCost 
= 
command #
.# $
	FinalCost$ -
,- .
Cost 
= 
command 
. 
Cost #
,# $
AppliedDiscounts  
=! "
new# &
List' +
<+ ,
DiscountRepository, >
>> ?
(? @
)@ A
} 
; 
_context   
.   
Invoices   
.   
Add   !
(  ! "
createdInvoice  " 0
)  0 1
;  1 2
_context!! 
.!! 
SaveChanges!!  
(!!  !
)!!! "
;!!" #
return## 
new## 
BaseResponseModel## (
<##( ) 
CreateInvoiceCommand##) =
>##= >
{$$ 
Data%% 
=%% 
new%%  
CreateInvoiceCommand%% /
(%%/ 0
)%%0 1
{&& 
Id'' 
='' 
createdInvoice'' '
.''' (
Id''( *
,''* +
InvoiceDate(( 
=((  !
createdInvoice((" 0
.((0 1
InvoiceDate((1 <
,((< =
UserId)) 
=)) 
createdInvoice)) +
.))+ ,
UserId)), 2
,))2 3
	FinalCost** 
=** 
createdInvoice**  .
.**. /
	FinalCost**/ 8
,**8 9
Cost++ 
=++ 
createdInvoice++ )
.++) *
Cost++* .
,++. /
},, 
,,, 
Status-- 
=-- 
true-- 
}.. 
;.. 
}// 	
}00 
}11 ü
dC:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Handler\DeleteInvoiceCommandHandler.cs
	namespace		 	
AssessmentProject		
 
.		 
Application		 '
.		' (
Invoice		( /
.		/ 0
Handler		0 7
{

 
public 

class '
DeleteInvoiceCommandHandler ,
{ 
private 
readonly 
DataContext $
_context% -
;- .
public '
DeleteInvoiceCommandHandler *
(* +
DataContext+ 6
context7 >
)> ?
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  ! 
DeleteInvoiceCommand! 5
>5 6
Handle7 =
(= > 
DeleteInvoiceCommand> R
commandS Z
)Z [
{ 	
var 
invoiceWillBeDelete #
=$ %
_context& .
.. /
Invoices/ 7
.7 8
FirstOrDefault8 F
(F G
iG H
=>I K
iL M
.M N
IdN P
==Q S
commandT [
.[ \
	InvoiceId\ e
)e f
;f g
if 
( 
invoiceWillBeDelete #
==$ &
null' +
)+ ,
{ 
return 
new 
BaseResponseModel ,
<, - 
DeleteInvoiceCommand- A
>A B
{ 
Status 
= 
false "
," #
Data 
= 
command "
," #
} 
; 
} 
_context 
. 
Remove 
( 
invoiceWillBeDelete /
)/ 0
;0 1
_context 
. 
SaveChanges  
(  !
)! "
;" #
_context   
.   
Dispose   
(   
)   
;   
return"" 
new"" 
BaseResponseModel"" (
<""( ) 
DeleteInvoiceCommand"") =
>""= >
{## 
Status$$ 
=$$ 
true$$ 
,$$ 
Data%% 
=%% 
command%% 
}&& 
;&& 
}'' 	
})) 
}** È
_C:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Handler\GetInvoiceQueryHandler.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Invoice

( /
.

/ 0
Handler

0 7
{ 
public 

class "
GetInvoiceQueryHandler '
{ 
private 
readonly 
DataContext $
_context% -
;- .
public "
GetInvoiceQueryHandler %
(% &
DataContext& 1
context2 9
)9 :
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  ! 
CreateInvoiceCommand! 5
>5 6
Handle7 =
(= >

GetInvoice> H
queryI N
)N O
{ 	
var 
invoice 
= 
_context "
." #
Invoices# +
.+ ,
FirstOrDefault, :
(: ;
i; <
=>= ?
i@ A
.A B
IdB D
==E G
queryH M
.M N
	InvoiceIdN W
)W X
;X Y
if 
( 
invoice 
== 
null 
)  
{ 
return 
new 
BaseResponseModel ,
<, - 
CreateInvoiceCommand- A
>A B
(B C
)C D
{ 
Status 
= 
false "
," #
} 
; 
} 
return 
new 
BaseResponseModel (
<( ) 
CreateInvoiceCommand) =
>= >
(> ?
)? @
{   
Status!! 
=!! 
true!! 
,!! 
Data"" 
="" 
new""  
CreateInvoiceCommand"" /
(""/ 0
)""0 1
{## 
InvoiceDate$$ 
=$$  !
invoice$$" )
.$$) *
InvoiceDate$$* 5
,$$5 6
Cost%% 
=%% 
invoice%% "
.%%" #
Cost%%# '
,%%' (
	FinalCost&& 
=&& 
invoice&&  '
.&&' (
	FinalCost&&( 1
,&&1 2
Id'' 
='' 
invoice''  
.''  !
Id''! #
,''# $
UserId(( 
=(( 
invoice(( $
.(($ %
UserId((% +
})) 
}** 
;** 
}++ 	
},, 
}-- º
dC:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Handler\UpdateInvoiceCommandHandler.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Invoice

( /
.

/ 0
Handler

0 7
{ 
public 

class '
UpdateInvoiceCommandHandler ,
{ 
private 
readonly 
DataContext $
_context% -
;- .
public '
UpdateInvoiceCommandHandler *
(* +
DataContext+ 6
context7 >
)> ?
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  ! 
UpdateInvoiceCommand! 5
>5 6
Handle7 =
(= > 
UpdateInvoiceCommand> R
commandS Z
)Z [
{ 	
var 
invoiceWillBeUpdate #
=$ %
_context& .
.. /
Invoices/ 7
.7 8
FirstOrDefault8 F
(F G
iG H
=>I K
iL M
.M N
IdN P
==Q S
commandT [
.[ \
	InvoiceId\ e
)e f
;f g
if 
( 
invoiceWillBeUpdate #
==$ &
null' +
)+ ,
{ 
return 
new 
BaseResponseModel ,
<, - 
UpdateInvoiceCommand- A
>A B
{ 
Status 
= 
false "
," #
} 
; 
} 
invoiceWillBeUpdate 
.  
	FinalCost  )
=* +
command, 3
.3 4
	FinalCost4 =
;= >
invoiceWillBeUpdate 
.  
Cost  $
=% &
command' .
.. /
Cost/ 3
;3 4
invoiceWillBeUpdate   
.    
InvoiceDate    +
=  , -
command  . 5
.  5 6
InvoiceDate  6 A
;  A B
_context!! 
.!! 
SaveChanges!!  
(!!  !
)!!! "
;!!" #
_context"" 
."" 
Dispose"" 
("" 
)"" 
;"" 
return$$ 
new$$ 
BaseResponseModel$$ (
<$$( ) 
UpdateInvoiceCommand$$) =
>$$= >
{%% 
Status&& 
=&& 
true&& 
,&& 
Data'' 
='' 
command'' 
,'' 
}(( 
;(( 
})) 	
}** 
}++ ã
SC:\Users\Eminf\Projects\AssessmentProject\Application\Invoice\Queries\GetInvoice.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Invoice( /
./ 0
Queries0 7
{		 
public

 

class

 

GetInvoice

 
{ 
public 
Guid 
	InvoiceId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} Ÿ
ZC:\Users\Eminf\Projects\AssessmentProject\Application\Store\Commands\CreateStoreCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Commands. 6
{ 
public		 

class		 
CreateStoreCommand		 #
{

 
public 
Guid 
StoreId 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public 
bool 
	IsGrocery 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ó
ZC:\Users\Eminf\Projects\AssessmentProject\Application\Store\Commands\DeleteStoreCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Commands. 6
{ 
public		 

class		 
DeleteStoreCommand		 #
{

 
public 
Guid 
StoreId 
{ 
get !
;! "
set# &
;& '
}( )
} 
}  
ZC:\Users\Eminf\Projects\AssessmentProject\Application\Store\Commands\UpdateStoreCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Commands. 6
{ 
public		 

class		 
UpdateStoreCommand		 #
{

 
public 
Guid 
StoreId 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
bool 
	IsGrocery 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ‡
`C:\Users\Eminf\Projects\AssessmentProject\Application\Store\Handler\CreateStoreCommandHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Handler. 5
{ 
public 

class %
CreateStoreCommandHandler *
{		 
private

 
readonly

 
DataContext

 $
_context

% -
;

- .
public %
CreateStoreCommandHandler (
(( )
DataContext) 4
context5 <
)< =
=>> @
_contextA I
=J K
contextL S
;S T
public 
BaseResponseModel  
<  !
CreateStoreCommand! 3
>3 4
Handle5 ;
(; <
CreateStoreCommand< N
commandO V
)V W
{ 	
var 
createdStore 
= 
new "
StoreRepository# 2
(2 3
)3 4
{ 
	IsGrocery 
= 
command #
.# $
	IsGrocery$ -
,- .
Name 
= 
command 
. 
Name #
,# $
Users 
= 
new 
List  
<  !
UserRepository! /
>/ 0
(0 1
)1 2
} 
; 
_context 
. 
Stores 
. 
Add 
(  
createdStore  ,
), -
;- .
_context 
. 
SaveChanges  
(  !
)! "
;" #
command 
. 
StoreId 
= 
createdStore *
.* +
Id+ -
;- .
return 
new 
BaseResponseModel (
<( )
CreateStoreCommand) ;
>; <
(< =
)= >
{ 
Status 
= 
true 
, 
Data 
= 
command 
, 
} 
; 
}   	
}!! 
}"" î
`C:\Users\Eminf\Projects\AssessmentProject\Application\Store\Handler\DeleteStoreCommandHandler.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Store

( -
.

- .
Handler

. 5
{ 
public 

class %
DeleteStoreCommandHandler *
{ 
private 
readonly 
DataContext $
_context% -
;- .
public %
DeleteStoreCommandHandler (
(( )
DataContext) 4
context5 <
)< =
=>> @
_contextA I
=J K
contextL S
;S T
public 
BaseResponseModel  
<  !
DeleteStoreCommand! 3
>3 4
Handle5 ;
(; <
DeleteStoreCommand< N
commandO V
)V W
{ 	
var 
storeWillBeDelete !
=" #
_context$ ,
., -
Stores- 3
.3 4
FirstOrDefault4 B
(B C
sC D
=>E G
sH I
.I J
IdJ L
==M O
commandP W
.W X
StoreIdX _
)_ `
;` a
if 
( 
storeWillBeDelete !
==" $
null% )
)) *
{ 
return 
new 
BaseResponseModel ,
<, -
DeleteStoreCommand- ?
>? @
(@ A
)A B
{ 
Status 
= 
false "
," #
} 
; 
} 
_context 
. 
Remove 
( 
storeWillBeDelete -
)- .
;. /
_context 
. 
SaveChanges  
(  !
)! "
;" #
return 
new 
BaseResponseModel (
<( )
DeleteStoreCommand) ;
>; <
(< =
)= >
{   
Status!! 
=!! 
true!! 
,!! 
Data"" 
="" 
command"" 
,"" 
}## 
;## 
}$$ 	
}%% 
}&& ﬂ
[C:\Users\Eminf\Projects\AssessmentProject\Application\Store\Handler\GetStoreQueryHandler.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
Store

( -
.

- .
Handler

. 5
{ 
public 

class  
GetStoreQueryHandler %
{ 
private 
readonly 
DataContext $
_context% -
;- .
public  
GetStoreQueryHandler #
(# $
DataContext$ /
context0 7
)7 8
=>9 ;
_context< D
=E F
contextG N
;N O
public 
BaseResponseModel  
<  !
CreateStoreCommand! 3
>3 4
Handle5 ;
(; <
GetStoreQuery< I
commandJ Q
)Q R
{ 	
var 
store 
= 
_context  
.  !
Stores! '
.' (
FirstOrDefault( 6
(6 7
s7 8
=>9 ;
s< =
.= >
Id> @
==A C
commandD K
.K L
StoreIdL S
)S T
;T U
if 
( 
store 
== 
null 
) 
{ 
return 
new 
BaseResponseModel ,
<, -
CreateStoreCommand- ?
>? @
(@ A
)A B
{ 
Status 
= 
false "
," #
} 
; 
} 
_context 
. 
Dispose 
( 
) 
; 
return 
new 
BaseResponseModel (
<( )
CreateStoreCommand) ;
>; <
(< =
)= >
{ 
Status 
= 
true 
, 
Data   
=   
new   
CreateStoreCommand   -
(  - .
)  . /
{!! 
	IsGrocery"" 
="" 
store""  %
.""% &
	IsGrocery""& /
,""/ 0
Name## 
=## 
store##  
.##  !
Name##! %
,##% &
StoreId$$ 
=$$ 
store$$ #
.$$# $
Id$$$ &
}%% 
,%% 
}&& 
;&& 
}'' 	
}(( 
})) ÷
`C:\Users\Eminf\Projects\AssessmentProject\Application\Store\Handler\UpdateStoreCommandHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Handler. 5
{ 
public 

class %
UpdateStoreCommandHandler *
{ 
private 
readonly 
DataContext $
_context% -
;- .
public %
UpdateStoreCommandHandler (
(( )
DataContext) 4
context5 <
)< =
=>> @
_contextA I
=J K
contextL S
;S T
public 
BaseResponseModel  
<  !
UpdateStoreCommand! 3
>3 4
Handle5 ;
(; <
UpdateStoreCommand< N
commandO V
)V W
{ 	
var 
storeWillBeUpdate !
=" #
_context$ ,
., -
Stores- 3
.3 4
FirstOrDefault4 B
(B C
sC D
=>E G
sH I
.I J
IdJ L
==M O
commandP W
.W X
StoreIdX _
)_ `
;` a
if 
( 
storeWillBeUpdate !
==" $
null% )
)) *
{ 
return 
new 
BaseResponseModel ,
<, -
UpdateStoreCommand- ?
>? @
(@ A
)A B
{ 
Status 
= 
false "
," #
} 
; 
} 
storeWillBeUpdate 
. 
Name "
=# $
command% ,
., -
Name- 1
;1 2
storeWillBeUpdate 
. 
	IsGrocery '
=( )
command* 1
.1 2
	IsGrocery2 ;
;; <
return"" 
new"" 
BaseResponseModel"" (
<""( )
UpdateStoreCommand"") ;
>""; <
(""< =
)""= >
{## 
Data$$ 
=$$ 
command$$ 
,$$ 
Status%% 
=%% 
true%% 
,%% 
}&& 
;&& 
}'' 	
}(( 
})) ã
TC:\Users\Eminf\Projects\AssessmentProject\Application\Store\Queries\GetStoreQuery.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
Store( -
.- .
Queries. 5
{ 
public		 

class		 
GetStoreQuery		 
{

 
public 
Guid 
StoreId 
{ 
get !
;! "
set# &
;& '
}( )
} 
} √

XC:\Users\Eminf\Projects\AssessmentProject\Application\User\Commands\CreateUserCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
User( ,
., -
Commands- 5
{ 
public		 

class		 
CreateUserCommand		 "
{

 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 
StoreId 
{ 
get !
;! "
set# &
;& '
}( )
public 
required 
bool 

IsEmployee '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
bool 
IsAffiliate (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} í
XC:\Users\Eminf\Projects\AssessmentProject\Application\User\Commands\DeleteUserCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
User( ,
., -
Commands- 5
{ 
public		 

class		 
DeleteUserCommand		 "
{

 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ™	
XC:\Users\Eminf\Projects\AssessmentProject\Application\User\Commands\UpdateUserCommand.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
User( ,
., -
Commands- 5
{ 
public		 

class		 
UpdateUserCommand		 "
{

 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Surname 
{ 
get  #
;# $
set% (
;( )
}* +
public 
required 
bool 

IsEmployee '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
required 
bool 
IsAffiliate (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ≠
^C:\Users\Eminf\Projects\AssessmentProject\Application\User\Handler\CreateUserCommandHandler.cs
	namespace

 	
AssessmentProject


 
.

 
Application

 '
.

' (
User

( ,
.

, -
Handler

- 4
{ 
public 

class $
CreateUserCommandHandler )
{ 
private 
readonly 
DataContext $
_context% -
;- .
public $
CreateUserCommandHandler '
(' (
DataContext( 3
context4 ;
); <
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !
CreateUserCommand! 2
>2 3
Handle4 :
(: ;
CreateUserCommand; L
commandM T
)T U
{ 	
var 
store 
= 
_context  
.  !
Stores! '
.' (
FirstOrDefault( 6
(6 7
s7 8
=>9 ;
s< =
.= >
Id> @
==A C
commandD K
.K L
StoreIdL S
)S T
;T U
if 
( 
store 
== 
null 
) 
{ 
return 
new 
BaseResponseModel ,
<, -
CreateUserCommand- >
>> ?
(? @
)@ A
{ 
Status 
= 
false "
," #
} 
; 
} 
var 
userWillBeCreate  
=! "
new# &
UserRepository' 5
(5 6
)6 7
{   
IsAffiliate!! 
=!! 
command!! %
.!!% &
IsAffiliate!!& 1
,!!1 2

IsEmployee"" 
="" 
command"" $
.""$ %

IsEmployee""% /
,""/ 0
Store## 
=## 
store## 
,## 
Name$$ 
=$$ 
command$$ 
.$$ 
Name$$ #
,$$# $
Surname%% 
=%% 
command%% !
.%%! "
Surname%%" )
}&& 
;&& 
_context(( 
.(( 
Users(( 
.(( 
Add(( 
((( 
userWillBeCreate(( /
)((/ 0
;((0 1
_context)) 
.)) 
SaveChanges))  
())  !
)))! "
;))" #
_context** 
.** 
Dispose** 
(** 
)** 
;** 
command,, 
.,, 
UserId,, 
=,, 
userWillBeCreate,, -
.,,- .
Id,,. 0
;,,0 1
return.. 
new.. 
BaseResponseModel.. (
<..( )
CreateUserCommand..) :
>..: ;
(..; <
)..< =
{// 
Data00 
=00 
command00 
,00 
Status11 
=11 
true11 
}22 
;22 
}33 	
}55 
}66 Ï
^C:\Users\Eminf\Projects\AssessmentProject\Application\User\Handler\DeleteUserCommandHandler.cs
	namespace		 	
AssessmentProject		
 
.		 
Application		 '
.		' (
User		( ,
.		, -
Handler		- 4
{

 
public 

class $
DeleteUserCommandHandler )
{ 
private 
readonly 
DataContext $
_context% -
;- .
public $
DeleteUserCommandHandler '
(' (
DataContext( 3
context4 ;
); <
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !
DeleteUserCommand! 2
>2 3
Handle4 :
(: ;
DeleteUserCommand; L
commandM T
)T U
{ 	
var 
userWillBeDelete  
=! "
_context# +
.+ ,
Users, 1
.1 2
FirstOrDefault2 @
(@ A
uA B
=>C E
uF G
.G H
IdH J
==K M
commandN U
.U V
UserIdV \
)\ ]
;] ^
if 
( 
userWillBeDelete  
==! #
null$ (
)( )
{ 
return 
new 
BaseResponseModel ,
<, -
DeleteUserCommand- >
>> ?
(? @
)@ A
{ 
Status 
= 
false "
," #
} 
; 
} 
_context 
. 
Remove 
( 
userWillBeDelete ,
), -
;- .
_context   
.   
SaveChanges    
(    !
)  ! "
;  " #
_context!! 
.!! 
Dispose!! 
(!! 
)!! 
;!! 
return## 
new## 
BaseResponseModel## (
<##( )
DeleteUserCommand##) :
>##: ;
(##; <
)##< =
{$$ 
Status%% 
=%% 
true%% 
,%% 
Data&& 
=&& 
command&& 
}'' 
;'' 
}(( 	
})) 
}** Ω
YC:\Users\Eminf\Projects\AssessmentProject\Application\User\Handler\GetUserQueryHandler.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
User( ,
., -
Handler- 4
{ 
public 

class 
GetUserQueryHandler $
{ 
private		 
readonly		 
DataContext		 $
_context		% -
;		- .
public

 
GetUserQueryHandler

 "
(

" #
DataContext

# .
context

/ 6
)

6 7
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !
CreateUserCommand! 2
>2 3
Handle4 :
(: ;
GetUserQuery; G
queryH M
)M N
{ 	
var 
user 
= 
_context 
.  
Users  %
.% &
FirstOrDefault& 4
(4 5
u5 6
=>7 9
u: ;
.; <
Id< >
==? A
queryB G
.G H
UserIdH N
)N O
;O P
if 
( 
user 
== 
null 
) 
{ 
return 
new 
BaseResponseModel ,
<, -
CreateUserCommand- >
>> ?
(? @
)@ A
{ 
Status 
= 
false "
," #
} 
; 
} 
return 
new 
BaseResponseModel (
<( )
CreateUserCommand) :
>: ;
(; <
)< =
{> ?
Status@ F
=G H
trueI M
,M N
DataO S
=T U
newV Y
CreateUserCommandZ k
(k l
)l m
{ 
Name 
= 
user 
. 
Name  
,  !
Surname 
= 
user 
. 
Surname &
,& '
UserId 
= 
user 
. 
Id  
,  !
IsAffiliate 
= 
user "
." #
IsAffiliate# .
,. /

IsEmployee   
=   
user   !
.  ! "

IsEmployee  " ,
}!! 
}!! 
;!! 
}"" 	
}## 
}$$ ‘
^C:\Users\Eminf\Projects\AssessmentProject\Application\User\Handler\UpdateUserCommandHandler.cs
	namespace		 	
AssessmentProject		
 
.		 
Application		 '
.		' (
User		( ,
.		, -
Handler		- 4
{

 
public 

class $
UpdateUserCommandHandler )
{ 
private 
readonly 
DataContext $
_context% -
;- .
public $
UpdateUserCommandHandler '
(' (
DataContext( 3
context4 ;
); <
{ 	
_context 
= 
context 
; 
} 	
public 
BaseResponseModel  
<  !
UpdateUserCommand! 2
>2 3
Handle4 :
(: ;
UpdateUserCommand; L
commandM T
)T U
{ 	
var 
userWillBeUpdate  
=! "
_context# +
.+ ,
Users, 1
.1 2
FirstOrDefault2 @
(@ A
uA B
=>C E
uF G
.G H
IdH J
==K M
commandN U
.U V
UserIdV \
)\ ]
;] ^
if 
( 
userWillBeUpdate  
==! #
null$ (
)( )
{ 
return 
new 
BaseResponseModel ,
<, -
UpdateUserCommand- >
>> ?
(? @
)@ A
{ 
Status 
= 
false "
," #
} 
; 
} 
userWillBeUpdate 
. 
Name !
=" #
command$ +
.+ ,
Name, 0
;0 1
userWillBeUpdate 
. 
Surname $
=% &
command' .
.. /
Surname/ 6
;6 7
userWillBeUpdate   
.   
IsAffiliate   (
=  ) *
command  + 2
.  2 3
IsAffiliate  3 >
;  > ?
userWillBeUpdate!! 
.!! 

IsEmployee!! '
=!!( )
command!!* 1
.!!1 2

IsEmployee!!2 <
;!!< =
_context## 
.## 
SaveChanges##  
(##  !
)##! "
;##" #
_context$$ 
.$$ 
Dispose$$ 
($$ 
)$$ 
;$$ 
return&& 
new&& 
BaseResponseModel&& (
<&&( )
UpdateUserCommand&&) :
>&&: ;
(&&; <
)&&< =
{'' 
Status(( 
=(( 
true(( 
,(( 
Data)) 
=)) 
command)) 
}** 
;** 
}++ 	
},, 
}-- Ü
RC:\Users\Eminf\Projects\AssessmentProject\Application\User\Queries\GetUserQuery.cs
	namespace 	
AssessmentProject
 
. 
Application '
.' (
User( ,
., -
Queries- 4
{ 
public		 

class		 
GetUserQuery		 
{

 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} 