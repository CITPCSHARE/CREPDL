module CREPDL.Registry


type Registry = 
  ISO10646 of string option * string option * int option
  | CLDR of string option * string option
  | IANA of  string option * string option * int  option