module CREPDL.ISO10646

//270,COMBINING CHARACTERS
//characters specified in annex B.1
//271,COMBINING CHARACTERS B-2
//characters specified in annex B.2
//281,MES-1  see A.4.1
//282,MES-2  see A.4.2
//283, MODERN EUROPEAN SCRIPTS  see A.4.3
//301, BMP-AMD.7  see A.3.1     
//302, BMP SECOND EDITION  see A.3.3     
//1900, SMP COMBINING CHARACTERS characters specified in annex B.1
//303, UNICODE 3.1  see A6.1
//304, UNICODE 3.2  see A6.2
//305, UNICODE 4.0  see A6.3
//340,COMBINED FIRST EDITION  see A5.1

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
       (15, " ARABIC EXTENDED",
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
       (33, " SUPERSCRIPTS AND SUBSCRIPTS",
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
       (39, " MATHEMATICAL OPERATORS",
            "0x2200, 0x22FF");
       (40, "MISCELLANEOUS TECHNICAL",
            "0x2300, 0x23FF");
       (41, "CONTROL PICTURES",
            "0x2400, 0x243F");
       (42, " OPTICAL CHARACTER  RECOGNITION",
            "0x2440, 0x245F");
       (43, "ENCLOSED ALPHANUMERICS",
            "0x2460, 0x24FF");
       (44, " BOX DRAWING",
            "0x2500, 0x257F");
       (45, " BLOCK ELEMENTS",
            "0x2580, 0x259F");
       (46, " GEOMETRIC SHAPES",
            "0x25A0, 0x25FF");
       (47, "MISCELLANEOUS SYMBOLS",
            "0x2600, 0x26FF");
       (48, "DINGBATS",
            "0x2700, 0x27BF");
       (49, " CJK SYMBOLS AND PUNCTUATION",
            "0x3000, 0x303F");
       (50, "HIRAGANA",
            "0x3040, 0x309F");
       (51, "KATAKANA",
            "0x30A0, 0x30FF");
       (52, "BOPOMOFO",
            "0x3100, 0x312F
            0x31A0, 0x31BF");
       (53, " HANGUL COMPATIBILITY JAMO",
            "0x3130, 0x318F");
       (54, "CJK MISCELLANEOUS",
            "0x3190, 0x319F");
       (55, " ENCLOSED CJK LETTERS AND MONTHS",
            "0x3200, 0x32FF");
       (56, " CJK COMPATIBILITY",
            "0x3300, 0x33FF");
       (60, "CJK UNIFIED IDEOGRAPHS",
            "0x4E00, 0x9FFF");
       (61, "PRIVATE USE AREA",
            "0xE000, 0xF8FF");
       (62, " CJK COMPATIBILITY IDEOGRAPHS",
            "0xF900, 0xFAFF");
       (64, "ARABIC PRESENTATION FORMS-A",
            "0xFB50, 0xFDCF
            0xFDF0, 0xFDFF");
       (65, " COMBINING HALF MARKS",
            "0xFE20, 0xFE2F");
       (66, " CJK COMPATIBILITY FORMS",
            "0xFE30, 0xFE4F");
       (67, "SMALL FORM VARIANTS",
            "0xFE50, 0xFE6F");
       (68, "ARABIC PRESENTATION FORMS-B",
            "0xFE70, 0xFEFE");
       (69, " HALFWIDTH AND FULLWIDTH  FORMS",
            "0xFF00, 0xFFEF");
       (70, "SPECIALS",
            "0xFFF0, 0xFFFD");
       (71, " HANGUL SYLLABLES",
            "0xAC00, 0xD7A3");
       (72, "BASIC TIBETAN",
            "0x0F00, 0x0FBF");
       (73, "ETHIOPIC",
            "0x1200, 0x137F");
       (74, " UNIFIED CANADIAN ABORIGINAL SYLLABICS",
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
       (98, " SUPPLEMENTAL ARROWS-A",
            "0x27F0, 0x27FF");
       (99, " SUPPLEMENTAL ARROWS-B",
            "0x2900, 0x297F");
       (100, "MISCELLANEOUS MATHEMATICAL SYMBOLS-B",
            "0x2980, 0x29FF");
       (101, "SUPPLEMENTAL MATHEMATICAL OPERATORS",
            "0x2A00, 0x2AFF");
       (102, "KATAKANA PHONETIC EXTENSIONS",
            "0x31F0, 0x31FF");
       (103, " VARIATION SELECTORS",
            "0xFE00, 0xFE0F");
       (104, " LTR ALPHABETIC PRESENTATION FORMS",
            "0xFB00, 0xFB1C");
       (105, " RTL ALPHABETIC PRESENTATION FORMS",
            "0xFB1D, 0xFB4F");
       (106, "LIMBU",
            "0x1900, 0x194F");
       (107, "TAI LE",
            "0x1950, 0x197F");
       (108, " KHMER SYMBOLS",
            "0x19E0, 0x19FF");
       (109, "PHONETIC EXTENSIONS",
            "0x1D00, 0x1D7F");
       (110, " MISCELLANEOUS SYMBOLS AND ARROWS",
            "0x2B00, 0x2BFF");
       (111, " YIJING HEXAGRAM SYMBOLS",
            "0x4DC0, 0x4DFF");
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
       (1014, " TAI XUAN JING SYMBOLS",
            "0x1D300, 0x1D35F");
       (2001, "CJK UNIFIED IDEOGRAPHS EXTENSION B",
            "0x20000, 0x2A6DF");
       (2002, " CJK COMPATIBILITY IDEOGRAPHS SUPPLEMENT",
            "0x2F800, 0x2FA1F");
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
       (204, " HANGUL FILL CHARACTERS",
            "0x3164
            0xFFA0");
       (205, "CHARACTER SHAPING SELECTORS",
            "0x206A, 0x206D");
       (206, " NUMERIC SHAPE SELECTORS",
            "0x206E, 0x206F");
       (207, " IDEOGRAPHIC DESCRIPTION CHARACTERS",
            "0x2FF0, 0x2FFF");
       (3002, "ALTERNATE FORMAT CHARACTERS",
            "0xE0000, 0xE0FFF");
       (300, "BMP",
            "0x0000, 0xD7FF
            0xE000, 0xFFFD");
       (1000, "SMP",
            "0x10000, 0x1FFFD");
       (2000, "SIP",
            "0x20000, 0x2FFFD");
       (3000, "SSP",
            "0xE0000, 0xEFFFD");
       (63, " ALPHABETIC PRESENTATION FORMS",
            "0xFB00, 0xFB1C
            0xFB1D, 0xFB4F");
       (250, " GENERAL FORMAT CHARACTERS",
            "0x200B, 0x200D
            0x2028, 0x2029
            0x200E, 0x200F
            0x202A, 0x202E
            0xFEFF");
       (251, " SCRIPT-SPECIFIC FORMAT CHARACTERS",
            "0x3164
            0xFFA0
            0x206A, 0x206D
            0x206E, 0x206F");
       (4000, " UCS PART-2",
            "0x10000, 0x1FFFD
            0x20000, 0x2FFFD
            0xE0000, 0xEFFFD");
       (380, " CJK UNIFIED IDEOGRAPHS-2001",
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
            0x2F800, 0x2FA1D")]

let deweyCollections() =
     [(370, "IICORE", "IICORE.txt")]
        
