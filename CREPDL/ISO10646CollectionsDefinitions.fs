﻿module CREPDL.ISO10646CollectionsDefinitions



let internal inLineCollections =
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
           (166,"CHEROKEE SUPPLEMENT",
               "0xAB70,0xABBF");
           (167,"CYRILLIC EXTENDED-C",
               "0x1C80,0x1C8F");
           (168,"SYRIAC SUPPLEMENT",
               "0x0860,0x086F");
           (169,"GEORGIAN EXTENDED",
               "0x1C90,0x1CBF");
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
           (1075, "SUPPLEMENTAL ARROWS-C",
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
           (1093, "OSAGE",
                "0x04B0,0x104FF");
           (1094, "MONGOLIAN SUPPLEMENT",
                "0x1660,0x1167F");
           (1095, "BHAIKSUKI",
                "0x1C00,0x11C6F");
           (1096, "MARCHEN",
                "0x1C70,0x11CBF");
           (1097, "IDEOGRAPHIC SYMBOLS AND PUNCTUATION",
                "0x6FE0,0x16FFF");
           (1098, "TANGUT",
                "0x7000,0x187EF");
           (1099, "TANGUT COMPONENTS",
                "0x8800,0x18AFF");
           (1100, "GLAGOLITIC SUPPLEMENT",
                "0xE000,0x1E02F");
           (1101, "SUPPLEMENTAL SYMBOLS AND PICTOGRAPHS",
                "0xF900,0x1F9FF");
           (1102, "HANIFI ROHINGGYA",
                "0x10D00,0x10D3F");
           (1103, "NEWA",
                "0x1400,0x1147F");
           (1104, "ZANABAZAR SQUARE",
                "0x1A00,0x11A4F");
           (1105, "SOYOMBO",
                "0x1A50,0x11AAF");
           (1106, "MASARAM GONDI",
                "0x1D00,0x11D5F");
           (1107, "NUSHU",
                "0xB170,0x1B2FF");
           (1108, "ADLAM",
                "0xE900,0x1E95F");
           (1109, "OLD SOGDIAN",
                "0x10F00,0x10F2F");
           (1110, "SOGDIAN",
                "0x10F30,0x10F6F");
           (1111, "DOGRA",
                "0x11800,0x1184F");
           (1112, "GUNJALA GONDI",
                "0x11D60,0x11DAF");
           (1113, "MAKASAR",
                "0x11EE0,0x11EFF");
           (1114, "MEDEFAIDRIN",
                "0x16E40,0x16E9F");
           (1115, "KANA EXTENDED-A",
                "0x1B100,0x1B12F");
           (1116, "MAYAN NUMERALS",
                "0x1D2E0,0x1D2FF");
           (1117, "INDIC SIYAQ NUMBERS",
                "0x1EC70,0x1ECBF");
           (1118, "CHESS SYMBOLS",
                "0x1FA00,0x1FA6F");
           (1120, "ELYMAIC",
                 "0x10FE0,0x10FFF");
           (1121, "NANDINAGARI",
                 "0x119A0,0x119FF");
           (1122, "TAMIL SUPPLEMENT",
                 "0x11FC0,0x11FFF");
           (1123, "EGYPTIAN HIEROGLYPHS FORMAT CONTROLS",
                 "0x13430,0x1343F");
           (1124, "SMALL KANA EXTENSION",
                 "0x1B130,0x1B16F");
           (1125, "NYIAKENG PUACHUE HMONG",
                 "0x1E100,0x1E14F");
           (1126, "WANCHO",
                 "0x1E2C0,0x1E2FF");
           (1127, "OTTOMAN SIYAQ NUMBERS",
                 "0x1ED00,0x1ED4F");
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
           (2006, "CJK UNIFIED IDEOGRAPHS EXTENSION F",
                "0x2CEB0,0x2EBEF");
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
            (10646, "UNICODE",
                "0x0000, 0xFDCF
                0xFDF0, 0xFFFD
                0x10000, 0x1FFFD
                0x20000, 0x2FFFD
                0x30000, 0x3FFFD
                0x40000, 0x4FFFD
                0x50000, 0x5FFFD
                0x60000, 0x6FFFD
                0x70000, 0x7FFFD
                0x80000, 0x8FFFD
                0x90000, 0x9FFFD
                0xA0000, 0xAFFFD
                0xB0000, 0xBFFFD
                0xC0000, 0xCFFFD
                0xD0000, 0xDFFFD
                0xE0000, 0xEFFFD
                0xF0000, 0xFFFFD
                0x100000, 0x10FFFD");
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

           (389,  "CJK UNIFIED IDEOGRAPHS-2016",
                 "0x3400, 0x4DB5
                 0x4E00, 0x9FA5
              0x9FA6,0x9FBB
              0x9FBC,0x9FC3
              0x9FC4,0x9FC6
              0x9FC7,0x9FCB
              0x9FCC,0x9FE9
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
              0x2B820,0x2CEA1
              0x2CEB0,0x2EBE0");

    //284 CONTEMPORARY LITHUANIAN LETTERS see A.5.5 *

           (300, "BMP",
                "0x0000, 0xD7FF
                0xE000, 0xFFFD");

           (401, "PRIVATE USE PLANES-0F-10",
                "0x0F0000,0x10FFFF")

           (1000, "SMP",
                "0x10000, 0x1FFFD");
           (2000, "SIP",
                "0x20000, 0x2FFFD");
           (3000, "SSP",
                "0xE0000, 0xEFFFD");
           (63, " ALPHABETIC PRESENTATION FORMS",
                "0xFB00, 0xFB1C
                0xFB1D, 0xFB4F");

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
            
let internal outOfLineCollections =
         [(281, "MES-1", "281.txt");
          (282, "MES-2", "282.txt");
          (-100285, "", "-100285.txt");
          (-200285, "", "-200285.txt");
          (-287, "", "-287.txt");
          (286, "JAPANESE NON IDEOGRAPHICS EXTENSION", "286.txt");
          (288, "MULTILINGUAL LATIN SUBSET", "288.txt");
          (301, "BMP-AMD.7", "301.txt");
          (302, "BMP SECOND EDITION", "302.txt");
          (0, "Age1-1", "Age1-1.txt");
          (0, "Age2-0", "Age2-0.txt");
          (0, "Age2-1", "Age2-1.txt");
          (0, "Age3-0", "Age3-0.txt");
          (0, "Age3-1", "Age3-1.txt");
          (0, "Age3-2", "Age3-2.txt");
          (0, "Age4-0", "Age4-0.txt");
          (0, "Age4-1", "Age4-1.txt");
          (0, "Age5-0", "Age5-0.txt");
          (0, "Age5-1", "Age5-1.txt");
          (0, "Age5-2", "Age5-2.txt");
          (0, "Age6-0", "Age6-0.txt");
          (0, "Age6-1", "Age6-1.txt");
          (0, "Age6-2", "Age6-2.txt");
          (0, "Age6-3", "Age6-3.txt");
          (0, "Age7-0", "Age7-0.txt");
          (0, "Age8-0", "Age8-0.txt");
          (0, "Age9-0", "Age9-0.txt");
          (0, "Age10-0", "Age10-0.txt");
          (0, "Age11-0", "Age11-0.txt");
          (0, "Age12-0", "Age12-0.txt");
          (0, "Age12-1", "Age12-1.txt");
          (-340, "", "-340.txt");
          (370, "IICORE", "IICORE.txt");
          (371, "JIS2004 IDEOGRAPHICS EXTENSION", "JIExt.txt");
          (372, "JAPANESE IDEOGRAPHICS SUPPLEMENT", "JAPANESE IDEOGRAPHICS SUPPLEMENT.txt");
          (373, "JAPANESE IT VENDORS CONTEMPORARY IDEOGRAPHS-1993", 
                "JAPANESE IT VENDORS CONTEMPORARY IDEOGRAPHS-1993.txt");
          (374, "JAPANESE JIS X 0213:2004 IDEOGRAPHS FROM PREVIOUS JIS STANDARDS",
                "JAPANESE JIS X 0213-2004 IDEOGRAPHS FROM PREVIOUS JIS STANDARDS.txt");
          (375, "JAPANESE CORE KANJI", 
                 "JapaneseCoreKanji.txt")]

let internal collectionsInCREPDL =
        [
           (270, "COMBINING CHARACTERS", 
                @"<intersection xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                  <char>[\p{Mc}|\p{Mn}|\p{Me}]</char>
                  <repertoire name=""BMP"" registry=""10646""/>
                </intersection>");
    

           (1900, "COMBINING CHARACTERS", 
                @"<intersection xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                  <char>[\p{Mc}|\p{Mn}|\p{Me}]</char>
                  <repertoire name=""SMP"" registry=""10646""/>
                </intersection>");

          (63, "ALPHABETIC PRESENTATION FORMS",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""104""/>
                      <repertoire  registry=""10646"" number=""105""/>
                    </union>");

          (250, "GENERAL FORMAT CHARACTERS",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""200""/>
                      <repertoire  registry=""10646"" number=""201""/>
                      <repertoire  registry=""10646"" number=""202""/>
                      <repertoire  registry=""10646"" number=""203""/>
                    </union>");

          (251, "SCRIPT-SPECIFIC FORMAT CHARACTERS", 
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""204""/>
                      <repertoire  registry=""10646"" number=""205""/>
                      <repertoire  registry=""10646"" number=""206""/>
                    </union>");
          (283, "MODERN EUROPEAN SCRIPTS",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""1""/>
                      <repertoire  registry=""10646"" number=""2""/>
                      <repertoire  registry=""10646"" number=""3""/>
                      <repertoire  registry=""10646"" number=""4""/>
                      <repertoire  registry=""10646"" number=""5""/>
                      <repertoire  registry=""10646"" number=""6""/>
                      <repertoire  registry=""10646"" number=""7""/>
                      <repertoire  registry=""10646"" number=""8""/>
                      <repertoire  registry=""10646"" number=""9""/>
                      <repertoire  registry=""10646"" number=""10""/>
                      <repertoire  registry=""10646"" number=""11""/>
                      <repertoire  registry=""10646"" number=""27""/>
                      <repertoire  registry=""10646"" number=""30""/>
                      <repertoire  registry=""10646"" number=""31""/>
                      <repertoire  registry=""10646"" number=""32""/>
                      <repertoire  registry=""10646"" number=""33""/>
                      <repertoire  registry=""10646"" number=""34""/>
                      <repertoire  registry=""10646"" number=""35""/>
                      <repertoire  registry=""10646"" number=""36""/>
                      <repertoire  registry=""10646"" number=""37""/>
                      <repertoire  registry=""10646"" number=""38""/>
                      <repertoire  registry=""10646"" number=""39""/>
                      <repertoire  registry=""10646"" number=""40""/>
                      <repertoire  registry=""10646"" number=""42""/>
                      <repertoire  registry=""10646"" number=""44""/>
                      <repertoire  registry=""10646"" number=""45""/>
                      <repertoire  registry=""10646"" number=""46""/>
                      <repertoire  registry=""10646"" number=""47""/>
                      <repertoire  registry=""10646"" number=""65""/>
                      <repertoire  registry=""10646"" number=""70""/>
                      <repertoire  registry=""10646"" number=""92""/>
                      <repertoire  registry=""10646"" number=""104""/>
                      <repertoire  registry=""10646"" number=""283""/>
                </union>");
          (285,  "BASIC JAPANESE",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""-100285""/>
                      <repertoire  registry=""10646"" number=""-200285""/>
                    </union>");
          (287,  "COMMON JAPANESE",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""285""/>
                      <repertoire  registry=""10646"" number=""-287""/>
                    </union>");


            (303, "UNICODE 3.1",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" name=""Age1-1""/>
                        <repertoire  registry=""10646"" name=""Age2-0""/>
                        <repertoire  registry=""10646"" name=""Age2-1""/>
                        <repertoire  registry=""10646"" name=""Age3-0""/>
                        <repertoire  registry=""10646"" name=""Age3-1""/>
                    </union>");

            (304, "UNICODE 3.2",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""303""/>
                        <repertoire  registry=""10646"" name=""Age3-2""/>
                    </union>");

            (305, "UNICODE 4.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""304""/>
                        <repertoire  registry=""10646"" name=""Age4-0""/>
                    </union>");

            (306, "UNICODE 4.1",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""305""/>
                        <repertoire  registry=""10646"" name=""Age4-1""/>
                    </union>");


            (307, "UNICODE 5.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""306""/>
                        <repertoire  registry=""10646"" name=""Age5-0""/>
                    </union>");
    
            (308, "UNICODE 5.1",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""307""/>
                        <repertoire  registry=""10646"" name=""Age5-1""/>
                    </union>");

            (309, "UNICODE 5.2",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""308""/>
                        <repertoire  registry=""10646"" name=""Age5-2""/>
                    </union>");

            (310, "UNICODE 6.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""309""/>
                        <repertoire  registry=""10646"" name=""Age6-0""/>
                    </union>");

            (311, "UNICODE 6.1",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""310""/>
                        <repertoire  registry=""10646"" name=""Age6-1""/>
                    </union>");

            (312, "UNICODE 6.2",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""311""/>
                        <repertoire  registry=""10646"" name=""Age6-2""/>
                    </union>");

            (313, "UNICODE 6.3",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""312""/>
                        <repertoire  registry=""10646"" name=""Age6-3""/>
                    </union>");

            (314, "UNICODE 7.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""313""/>
                        <repertoire  registry=""10646"" name=""Age7-0""/>
                    </union>"); 

            (315, "UNICODE 8.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""314""/>
                        <repertoire  registry=""10646"" name=""Age8-0""/>
                    </union>");

            (316, "UNICODE 9.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""315""/>
                        <repertoire  registry=""10646"" name=""Age9-0""/>
                    </union>");

            (317, "UNICODE 10.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""316""/>
                        <repertoire  registry=""10646"" name=""Age10-0""/>
                    </union>");

            (318, "UNICODE 11.0",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                        <repertoire  registry=""10646"" number=""317""/>
                        <repertoire  registry=""10646"" name=""Age11-0""/>
                    </union>");


          (340, "COMBINED FIRST EDITION",
                @"<union xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"">
                      <repertoire  registry=""10646"" number=""302""/>
                      <repertoire  registry=""10646"" number=""98""/>
                      <repertoire  registry=""10646"" number=""99""/>
                      <repertoire  registry=""10646"" number=""100""/>
                      <repertoire  registry=""10646"" number=""101""/>
                      <repertoire  registry=""10646"" number=""102""/>
                      <repertoire  registry=""10646"" number=""103""/>
                      <repertoire  registry=""10646"" number=""108""/>
                      <repertoire  registry=""10646"" number=""111""/>
                      <repertoire  registry=""10646"" number=""-340""/>
                    </union>");
          (390, "MOJI-JOHO-KIBAN IDEOGRAPHS-2016",
            @"<repertoire xmlns=""http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0"" 
                registry=""IVD"" name=""""/>");
          (4000, "UCS PART-2", """
                <union xmlns="http://purl.oclc.org/dsdl/crepdl/ns/structure/2.0">
                      <repertoire  registry="10646" number="1000"/>
                      <repertoire  registry="10646" number="2000"/>
                      <repertoire  registry="10646" number="3000"/>
                    </union>
                    """)];;
