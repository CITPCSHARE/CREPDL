module CREPDL.ISO10646

let rbtCollections() =
      [(1, "BASIC LATIN",
        "0x0020, 0x007E")
       (2, "LATIN-1 SUPPLEMENT",
            "0x00A0, 0x00FF");
       (3, "LATIN EXTENDED-A",
            "0x0100, 0x017F");
       (4, "LATIN EXTENDED-B",
            "0x0180, 0x024F");
       (5, "IPA EXTENSIONS",
            "0x0250, 0x02AF");
       (6, "SPACING MODIFIER LETTERS",
            "0x02B0, 0x02FF");
       (7, "COMBINING DIACRITICAL MARKS",
            "0x0300, 0x036F");
       (8, "BASIC GREEK",
            "0x0370, 0x03CF");
       (9, "GREEK SYMBOLS AND COPTIC",
            "0x03D0, 0x03FF");
       (10, "CYRILLIC",
            "0x0400, 0x04FF");
       (11, "ARMENIAN",
            "0x0530, 0x058F");
       (12, "BASIC HEBREW",
            "0x05D0, 0x05EA");
       (13, "HEBREW EXTENDED",
            "0x0590, 0x05CF
             0x05EB, 0x05FF");
       (14, "BASIC ARABIC",
            "0x0600, 0x065F");
       (15, "ARABIC EXTENDED",
            "0x0660, 0x06FF");
       (16, "DEVANAGARI",
            "0x0900, 0x097F
            0x200C
            0x200D");
       (17, "BENGALI",
            "0x0980, 0x09FF
            0x200C
            0x200D");
       (18, "GURMUKHI",
            "0x0A00, 0x0A7F
            0x200C
            0x200D");
       (19, "GUJARATI",
            "0x0A80, 0x0AFF
            0x200C
            0x200D");
       (20, "ORIYA",
            "0x0B00, 0x0B7F
            0x200C
            0x200D");
       (21, "TAMIL",
            "0x0B80, 0x0BFF
            0x200C
            0x200D");
       (22, "TELUGU",
            "0x0C00, 0x0C7F
            0x200C
            0x200D");
       (23, "KANNADA",
            "0x0C80, 0x0CFF
            0x200C
            0x200D");
       (24, "MALAYALAM",
            "0x0D00, 0x0D7F
            0x200C
            0x200D");
       (25, "THAI",
            "0x0E00, 0x0E7F");
       (26, "LAO",
            "0x0E80, 0x0EFF");
       (27, "BASIC GEORGIAN",
            "0x10D0, 0x10FF");
       (28, "GEORGIAN EXTENDED",
            "0x10A0, 0x10CF");
       (29, "HANGUL JAMO",
            "0x1100, 0x11FF");
       (30, "LATIN EXTENDED ADDITIONAL",
            "0x1E00, 0x1EFF");
       (31, "GREEK EXTENDED",
            "0x1F00, 0x1FFF");
       (32, "GENERAL PUNCTUATION",
            "0x2000, 0x206F");
       (33, "SUPERSCRIPTS AND SUBSCRIPTS",
            "0x2070, 0x209F");
       (34, "CURRENCY SYMBOLS",
            "0x20A0, 0x20CF");
       (35, "COMBINING DIACRITICAL MARKS FOR SYMBOLS",
            "0x20D0, 0x20FF");
       (36, "LETTERLIKE SYMBOLS",
            "0x2100, 0x214F");
       (37, "NUMBER FORMS",
            "0x2150, 0x218F");
       (38, "ARROWS",
            "0x2190, 0x21FF");
       (39, "MATHEMATICAL OPERATORS",
            "0x2200, 0x22FF");
       (40, "MISCELLANEOUS TECHNICAL",
            "0x2300, 0x23FF");
       (41, "CONTROL PICTURES",
            "0x2400, 0x243F");
       (42, "OPTICAL CHARACTER RECOGNITION",
            "0x2440, 0x245F");
       (43, "ENCLOSED ALPHANUMERICS",
            "0x2460, 0x24FF");
       (44, "BOX DRAWING",
            "0x2500, 0x257F");
       (45, "BLOCK ELEMENTS",
            "0x2580, 0x259F");
       (46, "GEOMETRIC SHAPES",
            "0x25A0, 0x25FF");
       (47, "MISCELLANEOUS SYMBOLS",
            "0x2600, 0x26FF");
       (48, "DINGBATS",
            "0x2700, 0x27BF");
       (49, "CJK SYMBOLS AND PUNCTUATION",
            "0x3000, 0x303F");
       (50, "HIRAGANA",
            "0x3040, 0x309F");
       (51, "KATAKANA",
            "0x30A0, 0x30FF");
       (52, "BOPOMOFO",
            "0x3100, 0x312F
            0x31A0, 0x31BF");
       (53, "HANGUL COMPATIBILITY JAMO",
            "0x3130, 0x318F");
       (54, "CJK MISCELLANEOUS",
            "0x3190, 0x319F");
       (55, "ENCLOSED CJK LETTERS AND MONTHS",
            "0x3200, 0x32FF");
       (56, "CJK COMPATIBILITY",
            "0x3300, 0x33FF");
       (60, "CJK UNIFIED IDEOGRAPHS",
            "0x4E00, 0x9FFF");
       (61, "PRIVATE USE AREA",
            "0xE000, 0xF8FF");
       (62, "CJK COMPATIBILITY IDEOGRAPHS",
            "0xF900, 0xFAFF");
       (64, "ARABIC PRESENTATION FORMS-A",
            "0xFB50, 0xFDCF
            0xFDF0, 0xFDFF");
       (65, "COMBINING HALF MARKS",
            "0xFE20, 0xFE2F");
       (66, "CJK COMPATIBILITY FORMS",
            "0xFE30, 0xFE4F");
       (67, "SMALL FORM VARIANTS",
            "0xFE50, 0xFE6F");
       (68, "ARABIC PRESENTATION FORMS-B",
            "0xFE70, 0xFEFE");
       (69, "HALFWIDTH AND FULLWIDTH FORMS",
            "0xFF00, 0xFFEF");
       (70, "SPECIALS",
            "0xFFF0, 0xFFFD");
       (71, "HANGUL SYLLABLES",
            "0xAC00, 0xD7A3");
       (72, "BASIC TIBETAN",
            "0x0F00, 0x0FBF");
       (73, "ETHIOPIC",
            "0x1200, 0x137F");
       (74, "UNIFIED CANADIAN ABORIGINAL SYLLABICS",
            "0x1400, 0x167F");
       (75, "CHEROKEE",
            "0x13A0, 0x13FF");
       (76, "YI SYLLABLES",
            "0xA000, 0xA48F");
       (77, "YI RADICALS",
            "0xA490, 0xA4CF");
       (78, "KANGXI RADICALS",
            "0x2F00, 0x2FDF");
       (79, "CJK RADICALS SUPPLEMENT",
            "0x2E80, 0x2EFF");
       (80, "BRAILLE PATTERNS",
            "0x2800, 0x28FF");
       (81, "CJK UNIFIED IDEOGRAPHS EXTENSION A",
            "0x3400, 0x4DBF
            0xFA1F
            0xFA23");
       (82, "OGHAM",
            "0x1680, 0x169F");
       (83, "RUNIC",
            "0x16A0, 0x16FF");
       (84, "SINHALA",
            "0x0D80, 0x0DFF");
       (85, "SYRIAC",
            "0x0700, 0x074F");
       (86, "THAANA",
            "0x0780, 0x07BF");
       (87, "BASIC MYANMAR",
            "0x1000, 0x104F
            0x200C
            0x200D");
       (88, "KHMER",
            "0x1780, 0x17FF
            0x200C
            0x200D");
       (89, "MONGOLIAN",
            "0x1800, 0x18AF");
       (90, "EXTENDED MYANMAR",
            "0x1050, 0x109F");
       (91, "TIBETAN",
            "0x0F00, 0x0FFF");
       (92, "CYRILLIC SUPPLEMENT",
            "0x0500, 0x052F");
       (93, "TAGALOG",
            "0x1700, 0x171F");
       (94, "HANUNOO",
            "0x1720, 0x173F");
       (95, "BUHID",
            "0x1740, 0x175F");
       (96, "TAGBANWA",
            "0x1760, 0x177F");
       (97, "MISCELLANEOUS MATHEMATICAL SYMBOLS-A",
            "0x27C0, 0x27EF");
       (98, "SUPPLEMENTAL ARROWS-A",
            "0x27F0, 0x27FF");
       (99, "SUPPLEMENTAL ARROWS-B",
            "0x2900, 0x297F");
       (100, "MISCELLANEOUS MATHEMATICAL SYMBOLS-B",
            "0x2980, 0x29FF");
       (101, "SUPPLEMENTAL MATHEMATICAL OPERATORS",
            "0x2A00, 0x2AFF");
       (102, "KATAKANA PHONETIC EXTENSIONS",
            "0x31F0, 0x31FF");
       (103, "VARIATION SELECTORS",
            "0xFE00, 0xFE0F");
       (104, "LTR ALPHABETIC PRESENTATION FORMS",
            "0xFB00, 0xFB1C");
       (105, "RTL ALPHABETIC PRESENTATION FORMS",
            "0xFB1D, 0xFB4F");
       (106, "LIMBU",
            "0x1900, 0x194F");
       (107, "TAI LE",
            "0x1950, 0x197F");
       (108, "KHMER SYMBOLS",
            "0x19E0, 0x19FF");
       (109, "PHONETIC EXTENSIONS",
            "0x1D00, 0x1D7F");
       (110, "MISCELLANEOUS SYMBOLS AND ARROWS",
            "0x2B00, 0x2BFF");
       (111, "YIJING HEXAGRAM SYMBOLS",
            "0x4DC0, 0x4DFF");
       (112,"ARABIC SUPPLEMENT",
           "0x0750,0x077F");
       (113,"ETHIOPIC SUPPLEMENT",
           "0x1380,0x139F");
       (114,"NEW TAI LUE",
           "0x1980,0x19DF");
       (115,"BUGINESE",
           "0x1A00,0x1A1F");
       (116,"PHONETIC EXTENSIONS SUPPLEMENT",
           "0x1D80,0x1DBF");
       (117,"COMBINING DIACRITICAL MARKS SUPPLEMENT",
           "0x1DC0,0x1DFF");
       (118,"GLAGOLITIC",
           "0x2C00,0x2C5F");
       (119,"COPTIC",
           "0x03E2,0x03EF
           0x2C80,0x2CFF");
       (120,"GEORGIAN SUPPLEMENT",
           "0x2D00,0x2D2F");
       (121,"TIFINAGH",
           "0x2D30,0x2D7F");
       (122,"ETHIOPIC EXTENDED",
           "0x2D80,0x2DDF");
       (123,"SUPPLEMENTAL PUNCTUATION",
           "0x2E00,0x2E7F");
       (124,"CJK STROKES",
           "0x31C0,0x31EF");
       (125,"MODIFIER TONE LETTERS",
           "0xA700,0xA71F");
       (126,"SYLOTI NAGRI",
           "0xA800,0xA82F");
       (127,"VERTICAL FORMS",
           "0xFE10,0xFE1F");
       (128,"NKO",
           "0x07C0,0x07FF");
       (129,"BALINESE",
           "0x1B00,0x1B7F");
       (130,"LATIN EXTENDED-C",
           "0x2C60,0x2C7F");
       (131,"LATIN EXTENDED-D",
           "0xA720,0xA7FF");
       (132,"PHAGS-PA",
           "0xA840,0xA87F");
       (133,"SUNDANESE",
           "0x1B80,0x1BBF" );
       (134,"LEPCHA",
           "0x1C00,0x1C4F");
       (135,"OL CHIKI",
           "0x1C50,0x1C7F" );
       (136,"VAI",
           "0xA500,0xA63F");
       (137,"SAURASHTRA",
           "0xA880,0xA8DF");
       (138,"KAYAH LI",
           "0xA900,0xA92F");
       (139,"REJANG",
           "0xA930,0xA95F");
       (140,"CYRILLIC EXTENDED-A",
           "0x2DE0,0x2DFF" );
       (141,"CYRILLIC EXTENDED-B",
           "0xA640,0xA69F");
       (142,"CHAM",
           "0xAA00,0xAA5F");
       (143,"TAI THAM",
           "0x1A20,0x1AAF");
       (144,"HANGUL JAMO EXTENDED-A",
           "0xA960,0xA97F");
       (145,"TAI VIET",
           "0xAA80,0xAADF");
       (146,"HANGUL JAMO EXTENDED-B",
           "0xD7B0,0xD7FF");
       (147,"SAMARITAN",
           "0x0800,0x083F");
       (148,"UNIFIED CANADIAN ABORIGINAL SYLLABICS EXTENDED",
           "0x18B0,0x18FF");
       (149,"VEDIC EXTENSIONS",
           "0x1CD0,0x1CFF");
       (150,"LISU",
           "0xA4D0,0xA4FF" );
       (151,"BAMUM",
           "0xA6A0,0xA6FF");
       (152,"COMMON INDIC NUMBER FORMS",
           "0xA830,0xA83F");
       (153,"DEVANAGARI EXTENDED",
           "0xA8E0,0xA8FF");
       (154,"JAVANESE",
           "0xA980,0xA9DF");
       (155,"MYANMAR EXTENDED-A",
           "0xAA60,0xAA7F" );
       (156,"MEETEI MAYEK",
           "0xABC0,0xABFF");
       (157,"MANDAIC",
           "0x0840,0x085F");
       (158,"BATAK",
           "0x1BC0,0x1BFF");
       (159,"ETHIOPIC EXTENDED-A",
           "0xAB00,0xAB2F");
       (160,"ARABIC EXTENDED-A",
           "0x08A0,0x08FF");
       (161,"SUNDANESE SUPPLEMENT",
           "0x1CC0,0x1CCF");
       (162,"MEETEI MAYEK EXTENSIONS",
           "0xAAE0,0xAAFF" );
       (163,"COMBINING DIACRITICAL MARKS EXTENDED",
           "0x1AB0,0x1AFF");
       (164,"MYANMAR EXTENDED-B",
           "0xA9E0,0xA9FF");
       (165,"LATIN EXTENDED-E",
           "0xAB30,0xAB6F");
       (1001, "OLD ITALIC",
            "0x10300, 0x1032F");
       (1002, "GOTHIC",
            "0x10330, 0x1034F");
       (1003, "DESERET",
            "0x10400, 0x1044F");
       (1004, "BYZANTINE MUSICAL SYMBOLS",
            "0x1D000, 0x1D0FF");
       (1005, "MUSICAL SYMBOLS",
            "0x1D100, 0x1D1FF");
       (1006, "MATHEMATICAL ALPHANUMERIC SYMBOLS",
            "0x1D400, 0x1D7FF");
       (1007, "LINEAR B SYLLABARY",
            "0x10000, 0x1007F");
       (1008, "LINEAR B IDEOGRAMS",
            "0x10080, 0x100FF");
       (1009, "AEGEAN NUMBERS",
            "0x10100, 0x1013F");
       (1010, "UGARITIC",
            "0x10380, 0x1039F");
       (1011, "SHAVIAN",
            "0x10450, 0x1047F");
       (1012, "OSMANYA",
            "0x10480, 0x104AF");
       (1013, "CYPRIOT SYLLABARY",
            "0x10800, 0x1083F");
       (1014, "TAI XUAN JING SYMBOLS",
            "0x1D300, 0x1D35F");
       (1015, "ANCIENT GREEK NUMBERS",
            "0x10140,0x1018F");
       (1016, "OLD PERSIAN",
            "0x103A0,0x103DF");
       (1017, "KHAROSHTHI",
            "0x10A00,0x10A5F");
       (1018, "ANCIENT GREEK MUSICAL NOTATION",
            "0x1D200,0x1D24F");
       (1019, "PHOENICIAN",
            "0x10900,0x1091F");
       (1020, "CUNEIFORM",
            "0x12000,0x123FF");
       (1021, "CUNEIFORM NUMBERS AND PUNCTUATION",
            "0x12400,0x1247F");
       (1022, "COUNTING ROD NUMERALS",
            "0x1D360,0x1D37F");
       (1023, "PHAISTOS DISC",
            "0x101D0,0x101FF");
       (1024, "LYCIAN",
            "0x10280,0x1029F");
       (1025, "CARIAN",
            "0x102A0,0x102DF");
       (1026, "LYDIAN",
            "0x10920,0x1093F");
       (1027, "ANCIENT SYMBOLS",
            "0x10190,0x101CF");
       (1028, "MAHJONG TILES",
            "0x1F000,0x1F02F");
       (1029, "DOMINO TILES",
            "0x1F030,0x1F09F");
       (1030, "AVESTAN",
            "0x10B00,0x10B3F");
       (1031, "EGYPTIAN HIEROGLYPHS",
            "0x13000,0x1342F");
       (1032, "IMPERIAL ARAMAIC",
            "0x10840,0x1085F");
       (1033, "OLD SOUTH ARABIAN",
            "0x10A60,0x10A7F");
       (1034, "INSCRIPTIONAL PARTHIAN",
            "0x10B40,0x10B5F");
       (1035, "INSCRIPTIONAL PAHLAVI",
            "0x10B60,0x10B7F");
       (1036, "OLD TURKIC",
            "0x10C00,0x10C4F");
       (1037, "RUMI NUMERAL SYMBOLS",
            "0x10E60,0x10E7F");
       (1038, "KAITHI",
            "0x11080,0x110CF");
       (1039, "ENCLOSED ALPHANUMERIC SUPPLEMENT",
            "0x1F100,0x1F1FF");
       (1040, "ENCLOSED IDEOGRAPHIC SUPPLEMENT",
            "0x1F200,0x1F2FF");
       (1041, "BRAHMI",
            "0x11000,0x1107F");
       (1042, "KANA SUPPLEMENT",
            "0x1B000,0x1B0FF");
       (1043, "BAMUM SUPPLEMENT",
            "0x16800,0x16A3F");
       (1044, "PLAYING CARDS",
            "0x1F0A0,0x1F0FF");
       (1045, "MISCELLANEOUS SYMBOLS AND PICTOGRAPHS",
            "0x1F300,0x1F5FF");
       (1046, "EMOTICONS",
            "0x1F600,0x1F64F");
       (1047, "TRANSPORT AND MAP SYMBOLS",
            "0x1F680,0x1F6FF");
       (1048, "ALCHEMICAL SYMBOLS",
            "0x1F700,0x1F77F");
       (1049, "MEROITIC HIEROGLYPHS",
            "0x10980,0x1099F");
       (1050, "MEROITIC CURSIVE",
            "0x109A0,0x109FF");
       (1051, "SORA SOMPENG",
            "0x110D0,0x110FF");
       (1052, "CHAKMA",
            "0x11100,0x1114F");
       (1053, "SHARADA",
            "0x11180,0x111DF");
       (1054, "TAKRI",
            "0x11680,0x116CF");
       (1055, "MIAO",
            "0x16F00,0x16F9F");
       (1056, "ARABIC MATHEMATICAL ALPHABETIC SYMBOLS",
            "0x1EE00,0x1EEFF");
       (1057, "COPTIC EPACT NUMBERS",
            "0x102E0,0x102FF");
       (1058, "ELBASAN",
            "0x10500,0x1052F");
       (1059, "LINEAR A",
            "0x10600,0x1077F");
       (1060, "PALMYRENE",
            "0x10860,0x1087F");
       (1061, "NABATAEAN",
            "0x10880,0x108AF");
       (1062, "OLD NORTH ARABIAN",
            "0x10A80,0x10A9F");
       (1063, "MANICHAEAN",
            "0x10AC0,0x10AFF");
       (1064, "SINHALA ARCHAIC NUMBERS",
            "0x111E0,0x111FF");
       (1065, "KHOJKI",
            "0x11200,0x1124F");
       (1066, "KHUDAWADI",
            "0x112B0,0x112FF");
       (1067, "TIRHUTA",
            "0x11480,0x114DF");
       (1068, "PAU CIN HAU",
            "0x11AC0,0x11AFF");
       (1069, "MRO",
            "0x16A40,0x16A6F");
       (1070, "BASSA VAH",
            "0x16AD0,0x16AFF");
       (1071, "DUPLOYAN",
            "0x1BC00,0x1BC9F");
       (1072, "SHORTHAND FORMAT CONTROLS",
            "0x1BCA0,0x1BCAF");
       (1073, "ORNAMENTAL DINGBATS",
            "0x1F650,0x1F67F");
       (1074, "GEOMETRIC SHAPES EXTENDED",
            "0x1F780,0x1F7FF");
       (1075, "SUPPLEMEMENTAL ARROWS-C",
            "0x1F800,0x1F8FF");
       (1076, "OLD PERMIC",
            "0x10350,0x1037F");
       (1077, "CAUCASIAN ALBANIAN",
            "0x10530,0x1056F");
       (1078, "PSALTER PAHLAVI",
            "0x10B80,0x10BAF");
       (1079, "MAHAJANI",
            "0x11150,0x1117F");
       (1080, "GRANTHA",
            "0x11300,0x1137F");
       (1081, "SIDDHAM",
            "0x11580,0x115FF");
       (1082, "MODI",
            "0x11600,0x1165F");
       (1083, "WARANG CITI",
            "0x118A0,0x118FF");
       (1084, "PAHAWH HMONG",
            "0x16B00,0x16B8F");
       (1085, "MENDE KIKAKUI",
            "0x1E800,0x1E8DF");
       (1086, "HATRAN",
            "0x108E0,0x108FF");
       (1087, "OLD HUNGARIAN",
            "0x10C80,0x10CFF");
       (1088, "MULTANI",
            "0x11280,0x112AF");
       (1089, "AHOM",
            "0x11700,0x1173F");
       (1090, "EARLY DYNASTIC CUNEIFORM",
            "0x12480,0x1254F");
       (1091, "ANATOLIAN HIEROGLYPHS",
            "0x14400,0x1467F");
       (1092, "SUTTON SIGNWRITING",
            "0x1D800,0x1DAAF");
       (2001, "CJK UNIFIED IDEOGRAPHS EXTENSION B",
            "0x20000, 0x2A6DF");
       (2002, "CJK COMPATIBILITY IDEOGRAPHS SUPPLEMENT",
            "0x2F800, 0x2FA1F");
       (2003, "CJK UNIFIED IDEOGRAPHS EXTENSION C",
            "0x2A700,0x2B73F");
       (2004, "CJK UNIFIED IDEOGRAPHS EXTENSION D",
            "0x2B740,0x2B81F");
       (2005, "CJK UNIFIED IDEOGRAPHS EXTENSION E",
            "0x2B820,0x2CEAF");
       (3001, "TAGS",
            "0xE0000, 0xE007F");
       (3003, "VARIATION SELECTORS SUPPLEMENT",
            "0xE0100, 0xE01EF");
       (200, "ZERO-WIDTH BOUNDARY INDICATORS",
            "0x200B, 0x200D
            0xFEFF");
       (201, "FORMAT SEPARATORS",
            "0x2028, 0x2029");
       (202, "BI-DIRECTIONAL FORMAT MARKS",
            "0x200E, 0x200F");
       (203, "BI-DIRECTIONAL FORMAT EMBEDDINGS",
            "0x202A, 0x202E");
       (204, "HANGUL FILL CHARACTERS",
            "0x3164
            0xFFA0");
       (205, "CHARACTER SHAPING SELECTORS",
            "0x206A, 0x206D");
       (206, "NUMERIC SHAPE SELECTORS",
            "0x206E, 0x206F");
       (207, "IDEOGRAPHIC DESCRIPTION CHARACTERS",
            "0x2FF0, 0x2FFF");
       (208, "CONTROL CHARACTERS",
            "0x0000, 0x001F
             0x0007F,0x009F");
       (3002, "ALTERNATE FORMAT CHARACTERS",
            "0xE0000, 0xE0FFF");

  
//303 UNICODE 3.1 see A.6.2 *
//304 UNICODE 3.2 see A.6.3 *
//305 UNICODE 4.0 see A.6.4 *
//306 UNICODE 4.1 see A.6.5 *
//307 UNICODE 5.0 see A.6.6 *
//308 UNICODE 5.1 see A.6.7 *
//309 UNICODE 5.2 see A.6.8 *
//310 UNICODE 6.0 see A.6.9 *
//311 UNICODE 6.1 see A.6.10 *
//312 UNICODE 6.2 see A.6.11 *
//313 UNICODE 6.3 see A.6.12 *
//314 UNICODE 7.0 see A.6.13 *
//340 COMBINED FIRST EDITION see A.3.5 *

//10646 UNICODE 0000-FDCF FDF0-FFFD 10000-1FFFD 20000-2FFFD 30000-3FFFD 40000-4FFFD 50000-5FFFD 60000-6FFFD 70000-7FFFD 80000-8FFFD 90000-9FFFD A0000-AFFFD B0000-BFFFD C0000-CFFFD D0000-DFFFD E0000-EFFFD F0000-FFFFD 100000-10FFFD 

       (380, "CJK UNIFIED IDEOGRAPHS-2001",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6");
       (381, "CJK COMPATIBILITY IDEOGRAPHS-2001",
            "0xF900, 0xFA0D
            0xFA10
            0xFA12
            0xFA15, 0xFA1E
            0xFA20
            0xFA22
            0xFA25, 0xFA26
            0xFA2A, 0xFA6A
            0x2F800, 0x2FA1D");

       (382, "CJK UNIFIED IDEOGRAPHS-2005",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
         0x9FA6,0x9FBB
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6");

       (383, "CJK COMPATIBILITY IDEOGRAPHS-2005",
            "0xF900, 0xFA0D
            0xFA10
            0xFA12
            0xFA15, 0xFA1E
            0xFA20
            0xFA22
            0xFA25, 0xFA26
            0xFA2A, 0xFA6A
          0xFA70, 0xFAD9
            0x2F800, 0x2FA1D");

       (384, "CJK UNIFIED IDEOGRAPHS-2007",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
         0x9FA6,0x9FBB
         0x9FBC,0x9FC3
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6");

       (385, "CJK UNIFIED IDEOGRAPHS-2008",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
         0x9FA6,0x9FBB
         0x9FBC,0x9FC3
         0x9FC4,0x9FC6
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6
         0x2A700,0x2B734");

       (386, "CJK COMPATIBILITY IDEOGRAPHS-2008",
            "0xF900, 0xFA0D
            0xFA10
            0xFA12
            0xFA15, 0xFA1E
            0xFA20
            0xFA22
            0xFA25, 0xFA26
            0xFA2A, 0xFA6A
          0xFA6B, 0xFA6D
          0xFA70, 0xFAD9
            0x2F800, 0x2FA1D");

       (387, "CJK UNIFIED IDEOGRAPHS-2009",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
         0x9FA6,0x9FBB
         0x9FBC,0x9FC3
         0x9FC4,0x9FC6
         0x9FC7,0x9FCB
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6
         0x2A700,0x2B734
         0x2B740,0x2B81D");

       (388, "CJK UNIFIED IDEOGRAPHS-2014",
            "0x3400, 0x4DB5
            0x4E00, 0x9FA5
         0x9FA6,0x9FBB
         0x9FBC,0x9FC3
         0x9FC4,0x9FC6
         0x9FC7,0x9FCB
            0xFA0E, 0xFA0F
            0xFA11
            0xFA13, 0xFA14
            0xFA1F
            0xFA21
            0xFA23, 0xFA24
            0xFA27, 0xFA29
            0x20000, 0x2A6D6
         0x2A700,0x2B734
         0x2B740,0x2B81D
         0x2B820,0x2CEA1");

//270 COMBINING CHARACTERS BMP characters specified in 4.14
//283 MODERN EUROPEAN SCRIPTS see A.5.4 *
//284 CONTEMPORARY LITHUANIAN LETTERS see A.5.5 *
//285 BASIC JAPANESE see A.5.6 *

       (300, "BMP",
            "0x0000, 0xD7FF
            0xE000, 0xFFFD");

       (401, "PRIVATE USE PLANES-0F-10",
            "0x0F0000,0x10FFFF")

       (1000, "SMP",
            "0x10000, 0x1FFFD");

//1900 SMP COMBINING CHARACTERS SMP characters specified in 4.14
//4.14  combining character character which has General Category values of 
//Spacing Combining Mark (Mc), Non Spacing Mark (Mn), and Enclosing Mark (Me) 

       (2000, "SIP",
            "0x20000, 0x2FFFD");
       (3000, "SSP",
            "0xE0000, 0xEFFFD");
       (63, " ALPHABETIC PRESENTATION FORMS",
            "0xFB00, 0xFB1C
            0xFB1D, 0xFB4F");

//63 ALPHABETIC PRESENTATION FORMS   Collections 104-105
//250 GENERAL FORMAT CHARACTERS  Collections 200-203
//251 SCRIPT-SPECIFIC FORMAT CHARACTERS Collections 204-206
//4000 UCS PART-2 Collections 1000, 2000, 3000

       (250, "GENERAL FORMAT CHARACTERS",
            "0x200B, 0x200D
            0x2028, 0x2029
            0x200E, 0x200F
            0x202A, 0x202E
            0xFEFF");
       (251, "SCRIPT-SPECIFIC FORMAT CHARACTERS",
            "0x3164
            0xFFA0
            0x206A, 0x206D
            0x206E, 0x206F");
       (4000, "UCS PART-2",
            "0x10000, 0x1FFFD
            0x20000, 0x2FFFD
            0xE0000, 0xEFFFD")]

let deweyCollections() =
     [(281, "MES-1", "281.txt");
      (282, "MES-2", "282.txt");
      (286, "JAPANESE NON IDEOGRAPHICS EXTENSION", "286.txt");
      (288, "MULTILINGUAL LATIN SUBSET", "288.txt");
      (301, "BMP-AMD.7", "301.txt");
      (302, "BMP SECOND EDITION", "302.txt");
      (370, "IICORE", "IICORE.txt");
      (371, "JIS2004 IDEOGRAPHICS EXTENSION", "JIExt.txt");
      (372, "JAPANESE IDEOGRAPHICS SUPPLEMENT", "JAPANESE IDEOGRAPHICS SUPPLEMENT.txt")]