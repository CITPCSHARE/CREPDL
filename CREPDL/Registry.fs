﻿module CREPDL.Registry


type internal Registry = 
  ISO10646 of string option * int option
  | CLDR of string option * string option
  | IANA of  string option * int  option
  | IVD of  string