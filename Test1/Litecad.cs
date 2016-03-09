using System;
using System.Runtime.InteropServices;

public delegate void F_LCEVENT (int hEvent);

public static class Lcad
{
  public const int LC_FALSE = 0;
  public const int LC_TRUE = 1;
  public const int LC_WS_HSCROLL = 1;
  public const int LC_WS_VSCROLL = 2;
  public const int LC_WS_BORDER = 4;
  public const int LC_WS_CLIENTEDGE = 8;
  public const int LC_WS_SUNKEN = 8;
  public const int LC_WS_STATICEDGE = 16;
  public const int LC_WS_VIEWTABS = 256;
  public const int LC_WS_RULERS = 512;
  public const int LC_WS_DEFAULT = 3;
  public const int LC_WS2_PROPWND = 1;
  public const int LC_WS2_RULERS = 2;
  public const int LC_WS2_SCROLLS = 4;
  public const int LC_WS2_STATBAR = 8;
  public const int LC_WS2_COORDS = 16;
  public const int LC_WS2_TOOLBAR = 32;
  public const int LC_WS2_DEFAULT = 47;
  public const int LC_MRU_IMAGE_W = 246;
  public const int LC_MRU_IMAGE_H = 190;
  public const int LC_PS_SOLID = 0;
  public const int LC_PS_DASH = 1;
  public const int LC_PS_DOT = 2;
  public const int LC_PS_DASHDOT = 3;
  public const int LC_PS_DASHDOTDOT = 4;
  public const int LC_LW_THIN = 0;
  public const int LC_LW_REAL = 1;
  public const int LC_LW_PIXEL = 2;
  public const int LC_FILL_SOLID = 0;
  public const int LC_FILL_BDIAGONAL = 1;
  public const int LC_FILL_CROSS = 2;
  public const int LC_FILL_DIAGCROSS = 3;
  public const int LC_FILL_FDIAGONAL = 4;
  public const int LC_FILL_HORIZONTAL = 5;
  public const int LC_FILL_VERTICAL = 6;
  public const int LC_FILL_NONE = 100;
  public const int LC_FILL_LINES = 101;
  public const int LC_FILL_HATCH = 102;
  public const int LC_IMGRES_BOX = 0;
  public const int LC_IMGRES_BILINEAR = 1;
  public const int LC_IMGRES_BSPLINE = 2;
  public const int LC_IMGRES_BICUBIC = 3;
  public const int LC_IMGRES_CATMULLROM = 4;
  public const int LC_IMGRES_LANCZOS3 = 5;
  public const int LC_GRIP_POINT = 0;
  public const int LC_GRIP_CENROT = 1;
  public const int LC_GRIP_ANGLE = 2;
  public const int LC_GRIP_ANGLE2 = 3;
  public const int LC_GRIP_BEZIER = 4;
  public const int LC_GRIP_BEZIER0 = 5;
  public const int LC_GRIP_ARCRAD = 6;
  public const int LC_BARTYPE_CODE39 = 0;
  public const int LC_BARTYPE_CODE93 = 1;
  public const int LC_BARTYPE_CODE128 = 6;
  public const int LC_BARTYPE_EAN13 = 7;
  public const int LC_BARTYPE_ITF = 8;
  public const int LC_BARTYPE_EAN8 = 9;
  public const int LC_BARTYPE_QR = 21;
  public const int LC_BARTYPE_MQR = 22;
  public const int LC_BARTYPE_DMATRIX = 23;
  public const int LC_BARC_QRECL_L = 0;
  public const int LC_BARC_QRECL_M = 1;
  public const int LC_BARC_QRECL_Q = 2;
  public const int LC_BARC_QRECL_H = 3;
  public const int LC_LEADER_TCENTER = 0;
  public const int LC_LEADER_TLEFT = 1;
  public const int LC_LEADER_TRIGHT = 2;
  public const int LC_LEADER_VERT = 1;
  public const int LC_LEADER_CORNER = 2;
  public const double LC_RAD_TO_DEG = 57.2957795130823208768;
  public const double LC_DEG_TO_RAD = 0.01745329251994329577;
  public const double LC_PI = 3.14159265358979323846;
  public const double LC_PI2 = 1.57079632679489661923;
  public const double LC_PI4 = 0.78539816339744830962;
  public const double LC_2PI = 6.28318530717958647692;
  public const double LC_DEG1 = 0.01745329251994329577;
  public const double LC_DEG2 = 0.03490658503988659154;
  public const double LC_DEG3 = 0.05235987755982988731;
  public const double LC_DEG4 = 0.06981317007977318308;
  public const double LC_DEG5 = 0.08726646259971647885;
  public const double LC_DEG6 = 0.10471975511965977462;
  public const double LC_DEG7 = 0.12217304763960307038;
  public const double LC_DEG8 = 0.13962634015954636615;
  public const double LC_DEG9 = 0.15707963267948966192;
  public const double LC_DEG10 = 0.17453292519943295769;
  public const double LC_DEG20 = 0.34906585039886591538;
  public const double LC_DEG30 = 0.52359877559829887308;
  public const double LC_DEG40 = 0.69813170079773183077;
  public const double LC_DEG45 = 0.78539816339744830962;
  public const double LC_DEG50 = 0.87266462599716478846;
  public const double LC_DEG60 = 1.04719755119659774615;
  public const double LC_DEG70 = 1.22173047639603070385;
  public const double LC_DEG80 = 1.39626340159546366154;
  public const double LC_DEG90 = 1.57079632679489661923;
  public const double LC_DEG180 = 3.14159265358979323846;
  public const double LC_DEG270 = 4.71238898038468985769;
  public const double LC_DEG360 = 6.28318530717958647692;
  public const int LC_INSUNIT_UNDEFINED = 0;
  public const int LC_INSUNIT_INCHES = 1;
  public const int LC_INSUNIT_FEET = 2;
  public const int LC_INSUNIT_MILES = 3;
  public const int LC_INSUNIT_MILLIMETERS = 4;
  public const int LC_INSUNIT_CENTIMETERS = 5;
  public const int LC_INSUNIT_METERS = 6;
  public const int LC_INSUNIT_KILOMETERS = 7;
  public const int LC_INSUNIT_MICROINCHES = 8;
  public const int LC_INSUNIT_MILS = 9;
  public const int LC_INSUNIT_YARDS = 10;
  public const int LC_INSUNIT_ANGSTROMS = 11;
  public const int LC_INSUNIT_NANOMETERS = 12;
  public const int LC_INSUNIT_MICRONS = 13;
  public const int LC_INSUNIT_DECIMETERS = 14;
  public const int LC_INSUNIT_DEKAMETERS = 15;
  public const int LC_INSUNIT_HECTOMETERS = 16;
  public const int LC_INSUNIT_GIGAMETERS = 17;
  public const int LC_INSUNIT_ASTRONOMICAL = 18;
  public const int LC_INSUNIT_LIGHTYEARS = 19;
  public const int LC_INSUNIT_PARSECS = 20;
  public const int LC_LUNIT_SCIEN = 1;
  public const int LC_LUNIT_DECIM = 2;
  public const int LC_LUNIT_ENGIN = 3;
  public const int LC_LUNIT_ARCHI = 4;
  public const int LC_LUNIT_FRACT = 5;
  public const int LC_AUNIT_DEGREE = 0;
  public const int LC_AUNIT_DMS = 1;
  public const int LC_AUNIT_GRAD = 2;
  public const int LC_AUNIT_RADIAN = 3;
  public const int LC_AUNIT_SURVEY = 4;
  public const int LC_ANGLE_DEGREE = 0;
  public const int LC_ANGLE_DMS = 1;
  public const int LC_ANGLE_GRAD = 2;
  public const int LC_ANGLE_RADIAN = 3;
  public const int LC_ANGLE_SURVEY = 4;
  public const int LC_PAPER_CUSTOM = 0;
  public const int LC_PAPER_USER = 0;
  public const int LC_PAPER_A0 = 1;
  public const int LC_PAPER_A1 = 2;
  public const int LC_PAPER_A2 = 3;
  public const int LC_PAPER_A3 = 4;
  public const int LC_PAPER_A4 = 5;
  public const int LC_PAPER_A5 = 6;
  public const int LC_PAPER_A6 = 7;
  public const int LC_PAPER_B0 = 11;
  public const int LC_PAPER_B1 = 12;
  public const int LC_PAPER_B2 = 13;
  public const int LC_PAPER_B3 = 14;
  public const int LC_PAPER_B4 = 15;
  public const int LC_PAPER_B5 = 16;
  public const int LC_PAPER_B6 = 17;
  public const int LC_PAPER_C0 = 21;
  public const int LC_PAPER_C1 = 22;
  public const int LC_PAPER_C2 = 23;
  public const int LC_PAPER_C3 = 24;
  public const int LC_PAPER_C4 = 25;
  public const int LC_PAPER_C5 = 26;
  public const int LC_PAPER_C6 = 27;
  public const int LC_PAPER_ANSI_A = 31;
  public const int LC_PAPER_ANSI_B = 32;
  public const int LC_PAPER_ANSI_C = 33;
  public const int LC_PAPER_ANSI_D = 34;
  public const int LC_PAPER_ANSI_E = 35;
  public const int LC_PAPER_LETTER = 36;
  public const int LC_PAPER_LEGAL = 37;
  public const int LC_PAPER_EXECUTIVE = 38;
  public const int LC_PAPER_LEDGER = 39;
  public const int LC_PAPER_PORTRAIT = 0;
  public const int LC_PAPER_BOOK = 0;
  public const int LC_PAPER_LANDSCAPE = 1;
  public const int LC_PAPER_ALBUM = 1;
  public const int LC_TA_LEFBOT = 0;
  public const int LC_TA_CENBOT = 1;
  public const int LC_TA_RIGBOT = 2;
  public const int LC_TA_LEFCEN = 3;
  public const int LC_TA_CENTER = 4;
  public const int LC_TA_RIGCEN = 5;
  public const int LC_TA_LEFTOP = 6;
  public const int LC_TA_CENTOP = 7;
  public const int LC_TA_RIGTOP = 8;
  public const int LC_TA_ALIGNED = 11;
  public const int LC_TA_FIT = 12;
  public const int LC_TEXT_BACKWARD = 2;
  public const int LC_TEXT_UPDOWN = 4;
  public const int LC_ATA_LEFT = 0;
  public const int LC_ATA_CENTER = 1;
  public const int LC_ATA_RIGHT = 2;
  public const int LC_BTA_LEFT = 0;
  public const int LC_BTA_CENTER = 1;
  public const int LC_BTA_RIGHT = 2;
  public const int LC_PLFIT_BULGE = 0;
  public const int LC_PLFIT_NONE = 0;
  public const int LC_PLFIT_QUAD = 5;
  public const int LC_PLFIT_CUBIC = 6;
  public const int LC_PLFIT_BEZIER = 7;
  public const int LC_PLFIT_SPLINE = 99;
  public const int LC_PLFIT_ROUND = 101;
  public const int LC_PLFIT_LINQUAD = 102;
  public const int LC_POINT_PIXEL = 0;
  public const int LC_POINT_NONE = 1;
  public const int LC_POINT_PLUS = 2;
  public const int LC_POINT_X = 3;
  public const int LC_POINT_TICK = 4;
  public const int LC_POINT_CIRCLE = 32;
  public const int LC_POINT_SQUARE = 64;
  public const int LC_POINT_RHOMB = 128;
  public const int LC_POINT_FILLED = 256;
  public const int LC_LBUTTON = 1;
  public const int LC_RBUTTON = 2;
  public const int LC_MBUTTON = 4;
  public const int LC_SHIFT = 1;
  public const int LC_CTRL = 2;
  public const int LC_ALT = 4;
  public const int LC_KBD_QWERTY = 0;
  public const int LC_KBD_AZERTY = 1;
  public const int LC_KBD_QWERTZ = 2;
  public const int LC_CURSOR_NULL = 0;
  public const int LC_CURSOR_ARROW = 1;
  public const int LC_CURSOR_CROSS = 2;
  public const int LC_CURSOR_HAND = 3;
  public const int LC_CURSOR_HELP = 4;
  public const int LC_CURSOR_NO = 5;
  public const int LC_CURSOR_WAIT = 6;
  public const int LC_CURSOR_PAN1 = 7;
  public const int LC_CURSOR_PAN2 = 8;
  public const int LC_EXP_OUTLINE = 1;
  public const int LC_EXP_HATCH = 2;
  public const int LC_EXP_ALL = 3;
  public const int LC_EXP_MAXRESOL = 4;
  public const int LC_HELP_DG_PRINT = 1;
  public const int LC_HELP_DG_RASTER = 2;
  public const int LC_HELP_DG_GBR_APERS = 4;
  public const int LC_HELP_DG_GBR_BITMAP = 5;
  public const int LC_HELP_DG_COLOR = 6;
  public const int LC_HELP_DG_LAYERS = 7;
  public const int LC_HELP_DG_SELLTYPE = 8;
  public const int LC_HELP_DG_LINETYPES = 9;
  public const int LC_HELP_DG_LOADLINETYPE = 10;
  public const int LC_HELP_DG_TEXTSTYLES = 11;
  public const int LC_HELP_DG_PNTSTYLES = 12;
  public const int LC_HELP_DG_DIMSTYLES = 13;
  public const int LC_HELP_DG_HATSTYLES = 14;
  public const int LC_HELP_DG_SELBLOCK = 15;
  public const int LC_HELP_DG_SELTSTYLE = 16;
  public const int LC_HELP_DG_SELPTYPE = 17;
  public const int LC_HELP_DG_CREBLOCK = 18;
  public const int LC_HELP_DG_BLOCKS = 19;
  public const int LC_HELP_DG_LAYOUTS = 20;
  public const int LC_HELP_DG_PAGEPROP = 21;
  public const int LC_HELP_DG_IMAGES = 22;
  public const int LC_HELP_DG_IMAGEINSERT = 23;
  public const int LC_HELP_DG_SELFONT = 24;
  public const int LC_HELP_DG_TEXT = 25;
  public const int LC_HELP_DG_ARCTEXT = 26;
  public const int LC_HELP_DG_INPUTCOORD = 27;
  public const int LC_HELP_DG_WORKFIELD = 28;
  public const int LC_HELP_DG_CRBITMAP = 29;
  public const int LC_HELP_DG_INSERT = 30;
  public const int LC_HELP_DG_TSP = 31;
  public const int LC_HELP_DG_ARRAY = 32;
  public const int LC_HELP_DG_ARRAYARC = 33;
  public const int LC_HELP_DG_HATCH = 34;
  public const int LC_HELP_DG_GRID = 41;
  public const int LC_HELP_DG_PTRACK = 42;
  public const int LC_HELP_DG_OSNAP = 43;
  public const int LC_HELP_DG_KBMOVE = 44;
  public const int LC_UNDO_BEGIN = 0;
  public const int LC_UNDO_END = 1;
  public const int LC_ERR_OBJTYPE = 1;
  public const int LC_ERR_NOTAG = 2;
  public const int LC_ERR_USERCANCEL = 3;
  public const int LC_ERR_FILENAME = 4;
  public const int LC_ERR_FILELOAD = 5;
  public const int LC_ERR_FILESAVE = 6;
  public const int LC_ERR_UNRESBLOCKREF = 7;
  public const int LC_ERR_UNRESVIEWREF = 8;
  public const int LC_ERR_UNRESHATCH = 9;
  public const int LC_OBJ_LAYER = 1;
  public const int LC_OBJ_LINETYPE = 2;
  public const int LC_OBJ_TEXTSTYLE = 3;
  public const int LC_OBJ_DIMSTYLE = 4;
  public const int LC_OBJ_PNTSTYLE = 5;
  public const int LC_OBJ_IMAGE = 6;
  public const int LC_OBJ_IMAGECAM = 7;
  public const int LC_OBJ_MLSTYLE = 8;
  public const int LC_OBJ_FILLING = 9;
  public const int LC_OBJ_BLOCK = 10;
  public const int LC_OBJ_LAYOUT = 11;
  public const int LC_ENT_LINE = 101;
  public const int LC_ENT_POLYLINE = 102;
  public const int LC_ENT_CIRCLE = 103;
  public const int LC_ENT_ARC = 104;
  public const int LC_ENT_BLOCKREF = 105;
  public const int LC_ENT_POINT = 107;
  public const int LC_ENT_XLINE = 108;
  public const int LC_ENT_ELLIPSE = 109;
  public const int LC_ENT_TEXT = 110;
  public const int LC_ENT_TEXTWIN = 111;
  public const int LC_ENT_IMAGEREF = 115;
  public const int LC_ENT_VIEWPORT = 116;
  public const int LC_ENT_CLIPRECT = 117;
  public const int LC_ENT_RECT = 118;
  public const int LC_ENT_ATTRIB = 120;
  public const int LC_ENT_ECW = 121;
  public const int LC_ENT_MTEXT = 122;
  public const int LC_ENT_ARCTEXT = 123;
  public const int LC_ENT_HATCH = 124;
  public const int LC_ENT_MLINE = 127;
  public const int LC_ENT_DIMROT = 131;
  public const int LC_ENT_DIMLIN = 131;
  public const int LC_ENT_DIMALI = 132;
  public const int LC_ENT_DIMORD = 133;
  public const int LC_ENT_DIMRAD = 134;
  public const int LC_ENT_DIMDIA = 135;
  public const int LC_ENT_DIMANG = 136;
  public const int LC_ENT_LEADER = 137;
  public const int LC_ENT_RPLAN = 141;
  public const int LC_ENT_TIN = 142;
  public const int LC_ENT_BARCODE = 150;
  public const int LC_ENT_ARROW = 301;
  public const int LC_ENT_SPIRAL = 302;
  public const int LC_ENT_CUSTOM = 1000;
  public const int LC_ENT_ALL = 32767;
  public const int LC_LWEIGHT_DEFAULT = -3;
  public const int LC_LWEIGHT_BYBLOCK = -2;
  public const int LC_LWEIGHT_BYLAYER = -1;
  public const int LC_LWIDTH_DEFAULT = -3;
  public const int LC_LWIDTH_BYBLOCK = -2;
  public const int LC_LWIDTH_BYLAYER = -1;
  public const int LC_COLOR_RGB = 0;
  public const int LC_COLOR_INDEX = 1;
  public const int LC_COLOR_RED = 1;
  public const int LC_COLOR_YELLOW = 2;
  public const int LC_COLOR_GREEN = 3;
  public const int LC_COLOR_CYAN = 4;
  public const int LC_COLOR_BLUE = 5;
  public const int LC_COLOR_MAGENTA = 6;
  public const int LC_COLOR_FOREGROUND = 7;
  public const int LC_COLOR_GRAY = 8;
  public const int LC_COLOR_LTGRAY = 9;
  public const int LC_COLOR_BYBLOCK = 0;
  public const int LC_COLOR_BYLAYER = 256;
  public const int LC_MLINE_TOP = 0;
  public const int LC_MLINE_MIDDLE = 1;
  public const int LC_MLINE_BOTTOM = 2;
  public const int LC_PLUG_IMPDRW = 2;
  public const int LC_PLUG_EXPDRW = 3;
  public const int LC_PLUG_IMGDIB = 4;
  public const int LC_FP_FLOAD = 0;
  public const int LC_FP_FSAVE = 1;
  public const int LC_FP_NITEMS = 2;
  public const int LC_FP_ITEM = 3;
  public const int LC_SNAP_NULL = 0;
  public const int LC_SNAP_NODE = 1;
  public const int LC_SNAP_ENDPOINT = 2;
  public const int LC_SNAP_MIDPOINT = 4;
  public const int LC_SNAP_CENTER = 8;
  public const int LC_SNAP_NEAREST = 16;
  public const int LC_SNAP_INTER = 32;
  public const int LC_SNAP_PERPEND = 64;
  public const int LC_SNAP_TANGENT = 128;
  public const int LC_SNAP_QUADRANT = 256;
  public const int LC_SNAP_INSERT = 512;
  public const int LC_SNAP_NONE = 1024;
  public const int LC_SNAP_ALL = 1023;
  public const int LC_ATTRIB_HIDDEN = 1;
  public const int LC_ATTRIB_CONST = 2;
  public const int LC_ATTRIB_VERIFY = 4;
  public const int LC_ATTRIB_PRESET = 8;
  public const int LC_ATTRIB_LOCK = 16;
  public const int LC_ATTRIB_MTEXT = 32;
  public const int LC_BLOCK_OVERWRITENO = 0;
  public const int LC_BLOCK_OVERWRITEYES = 1;
  public const int LC_BLOCK_OVERWRITEDLG = 2;
  public const int LC_ARROW_CLOSEDF = 0;
  public const int LC_ARROW_CLOSEDB = 1;
  public const int LC_ARROW_CLOSED = 2;
  public const int LC_ARROW_DOT = 3;
  public const int LC_ARROW_ARCHTICK = 4;
  public const int LC_ARROW_OBLIQUE = 5;
  public const int LC_ARROW_OPEN = 6;
  public const int LC_ARROW_ORIGIN = 7;
  public const int LC_ARROW_ORIGIN2 = 8;
  public const int LC_ARROW_OPEN90 = 9;
  public const int LC_ARROW_OPEN30 = 10;
  public const int LC_ARROW_DOTSMALL = 11;
  public const int LC_ARROW_DOTB = 12;
  public const int LC_ARROW_DOTSMALLB = 13;
  public const int LC_ARROW_BOX = 14;
  public const int LC_ARROW_BOXF = 15;
  public const int LC_ARROW_DATUM = 16;
  public const int LC_ARROW_DATUMF = 17;
  public const int LC_ARROW_INTEGRAL = 18;
  public const int LC_ARROW_NONE = 19;
  public const int LC_CMD_FILESAVE = 1;
  public const int LC_CMD_FILESAVEAS = 2;
  public const int LC_CMD_PRINT = 3;
  public const int LC_CMD_RASTERIZE = 4;
  public const int LC_CMD_FILENEW = 5;
  public const int LC_CMD_FILEOPEN = 6;
  public const int LC_CMD_FILERECENT = 7;
  public const int LC_CMD_ZOOM_IN = 401;
  public const int LC_CMD_ZOOM_OUT = 402;
  public const int LC_CMD_ZOOM_EXT = 403;
  public const int LC_CMD_ZOOM_PREV = 405;
  public const int LC_CMD_PAN_LEFT = 407;
  public const int LC_CMD_PAN_RIGHT = 408;
  public const int LC_CMD_PAN_UP = 409;
  public const int LC_CMD_PAN_DOWN = 410;
  public const int LC_CMD_ZOOM_WIN = 421;
  public const int LC_CMD_ZOOM_RECT = 421;
  public const int LC_CMD_PAGENEXT = 423;
  public const int LC_CMD_PAGEPREV = 424;
  public const int LC_CMD_PAGEMODEL = 425;
  public const int LC_CMD_GRID = 101;
  public const int LC_CMD_OSNAP = 102;
  public const int LC_CMD_PTRACK = 103;
  public const int LC_CMD_DIST = 104;
  public const int LC_CMD_AREA = 105;
  public const int LC_CMD_SELOPTS = 106;
  public const int LC_CMD_QSELECT = 107;
  public const int LC_CMD_WORKFIELD = 109;
  public const int LC_CMD_WORKFIELDPRM = 110;
  public const int LC_CMD_JUMPLINES = 111;
  public const int LC_CMD_JUMPLINESPRM = 112;
  public const int LC_CMD_TSP2 = 114;
  public const int LC_CMD_KBMOVE = 131;
  public const int LC_CMD_CAMERA = 132;
  public const int LC_CAMERA_ON = 1;
  public const int LC_CAMERA_OFF = 2;
  public const int LC_CAMERA_TIME = 3;
  public const int LC_CMD_HELP = 1001;
  public const int LC_CMD_RESET = 1003;
  public const int LC_CMD_POINT = 201;
  public const int LC_CMD_LINE = 202;
  public const int LC_CMD_XLINE = 203;
  public const int LC_XLINE_BASE = 1;
  public const int LC_XLINE_ANG = 2;
  public const int LC_XLINE_SEP = 3;
  public const int LC_XLINE_RAY = 4;
  public const int LC_XLINE_XLINE = 5;
  public const int LC_CMD_POLYLINE = 205;
  public const int LC_CMD_PLINE = 205;
  public const int LC_CMD_RECT = 207;
  public const int LC_RECT_2P = 1;
  public const int LC_RECT_3P = 2;
  public const int LC_RECT_CSA = 3;
  public const int LC_CMD_CIRCLE = 208;
  public const int LC_CIRCLE_CR = 1;
  public const int LC_CIRCLE_2P = 2;
  public const int LC_CIRCLE_3P = 3;
  public const int LC_CMD_ARC = 209;
  public const int LC_ARC_SME = 1;
  public const int LC_ARC_SEM = 2;
  public const int LC_ARC_SEC = 3;
  public const int LC_ARC_SED = 4;
  public const int LC_ARC_CSE = 5;
  public const int LC_ARC_CONT = 6;
  public const int LC_CMD_ELLIPSE = 210;
  public const int LC_ELL_AX = 1;
  public const int LC_ELL_CEN = 2;
  public const int LC_ELL_RECT = 3;
  public const int LC_CMD_TEXT = 211;
  public const int LC_CMD_ATEXT = 212;
  public const int LC_CMD_ARCTEXT = 212;
  public const int LC_CMD_MTEXT = 213;
  public const int LC_CMD_INSERT = 214;
  public const int LC_CMD_BARCODE = 215;
  public const int LC_BARCODE_39 = 1;
  public const int LC_BARCODE_93 = 2;
  public const int LC_BARCODE_128 = 3;
  public const int LC_BARCODE_EAN13 = 4;
  public const int LC_BARCODE_EAN8 = 5;
  public const int LC_BARCODE_ITF = 6;
  public const int LC_BARCODE_MQR = 7;
  public const int LC_BARCODE_QR = 8;
  public const int LC_BARCODE_DMATRIX = 9;
  public const int LC_CMD_DIMLIN = 216;
  public const int LC_CMD_DIMALI = 217;
  public const int LC_CMD_DIMORD = 218;
  public const int LC_CMD_DIMRAD = 219;
  public const int LC_CMD_DIMDIA = 220;
  public const int LC_CMD_DIMANG = 221;
  public const int LC_CMD_LEADER = 222;
  public const int LC_CMD_ARROW = 223;
  public const int LC_CMD_SPIRAL = 224;
  public const int LC_CMD_HATCH = 225;
  public const int LC_CMD_ECW = 226;
  public const int LC_CMD_CLRECT = 231;
  public const int LC_CMD_CLRECT_DEL = 232;
  public const int LC_CMD_CLRECT_DIV = 233;
  public const int LC_CMD_CLRECT_CBCOPY = 234;
  public const int LC_CMD_CLRECT_BITMAP = 235;
  public const int LC_CMD_CLRECT_BITMAP2 = 236;
  public const int LC_CMD_CLRECT_HIDE = 237;
  public const int LC_CMD_SW_GRID = 1011;
  public const int LC_CMD_SW_GRIDSNAP = 1012;
  public const int LC_CMD_SW_LWEIGHT = 1013;
  public const int LC_CMD_SW_OSNAP = 1014;
  public const int LC_CMD_SW_PTRACK = 1015;
  public const int LC_CMD_SW_POLAR = 1015;
  public const int LC_CMD_SW_ORTHO = 1016;
  public const int LC_CMD_SNAP_NONE = 1100;
  public const int LC_CMD_SNAP_NODE = 1101;
  public const int LC_CMD_SNAP_ENDPOINT = 1102;
  public const int LC_CMD_SNAP_MIDPOINT = 1103;
  public const int LC_CMD_SNAP_CENTER = 1104;
  public const int LC_CMD_SNAP_QUADRANT = 1105;
  public const int LC_CMD_SNAP_NEAREST = 1106;
  public const int LC_CMD_SNAP_INTER = 1107;
  public const int LC_CMD_SNAP_PERPEND = 1108;
  public const int LC_CMD_SNAP_TANGENT = 1109;
  public const int LC_CMD_SNAP_INSERT = 1110;
  public const int LC_CMD_SNAP_DIALOG = 1111;
  public const int LC_CMD_CBCUT = 301;
  public const int LC_CMD_CBCOPY = 302;
  public const int LC_CMD_CBPASTE = 303;
  public const int LC_CMD_UNDO = 304;
  public const int LC_CMD_REDO = 305;
  public const int LC_CMD_COPY = 306;
  public const int LC_COPY_MOVE = 1;
  public const int LC_COPY_ROTATE = 2;
  public const int LC_COPY_SCALE = 3;
  public const int LC_COPY_MIRROR = 4;
  public const int LC_COPY_ARRRECT = 5;
  public const int LC_COPY_ARRCIRC = 6;
  public const int LC_CMD_ERASE = 307;
  public const int LC_CMD_MOVE = 308;
  public const int LC_CMD_ROTATE = 309;
  public const int LC_CMD_SCALE = 310;
  public const int LC_CMD_MIRROR = 311;
  public const int LC_CMD_EXPLODE = 312;
  public const int LC_CMD_JOIN = 314;
  public const int LC_CMD_DEP = 315;
  public const int LC_CMD_ORDER = 316;
  public const int LC_ORDER_FRONT = 1;
  public const int LC_ORDER_BACK = 2;
  public const int LC_ORDER_ABOVE = 3;
  public const int LC_ORDER_UNDER = 4;
  public const int LC_ORDER_SWAP = 5;
  public const int LC_ORDER_SEQUENCE = 6;
  public const int LC_CMD_CLOSEBLOCK = 317;
  public const int LC_CMD_BASEPOINT = 318;
  public const int LC_CMD_TRIM = 319;
  public const int LC_CMD_EXTEND = 320;
  public const int LC_CMD_OFFSET = 321;
  public const int LC_CMD_OFFSET_POINT = 0;
  public const int LC_CMD_OFFSET_DIST = 1;
  public const int LC_CMD_BREAK = 322;
  public const int LC_CMD_STRETCH = 323;
  public const int LC_CMD_FILLET = 324;
  public const int LC_CMD_IMGRES = 343;
  public const int LC_CMD_IMGPOS = 344;
  public const int LC_CMD_LAYER = 501;
  public const int LC_CMD_LAYERORD = 502;
  public const int LC_CMD_COLOR = 503;
  public const int LC_CMD_FCOLOR = 504;
  public const int LC_CMD_LINETYPE = 505;
  public const int LC_CMD_TEXTSTYLE = 507;
  public const int LC_CMD_BLOCK = 508;
  public const int LC_CMD_CREBLOCK = 508;
  public const int LC_CMD_BLOCKS = 509;
  public const int LC_CMD_IMAGE = 510;
  public const int LC_CMD_PNTSTYLE = 511;
  public const int LC_CMD_DIMSTYLE = 512;
  public const int LC_CMD_MLSTYLE = 513;
  public const int LC_CMD_HATSTYLE = 514;
  public const int LC_CMD_FILLING = 515;
  public const int LC_CMD_LAYOUT = 516;
  public const int LC_CMD_UNITS = 517;
  public const int LC_CMD_DRWPRM = 518;
  public const int LC_CMDBLOCK_EDIT = 32151;
  public const int LC_CMDBLOCK_ATT = 32152;
  public const int LC_CMD_GBR_APERTURES = 9001;
  public const int LC_CMD_GBR_BITMAP = 9002;
  public const int LC_CMD_CUSTOM = 30000;
  public const int LC_PROP_G_VERSION = 1;
  public const int LC_PROP_G_MSGTITLE = 2;
  public const int LC_PROP_G_HELPFILE = 10;
  public const int LC_PROP_G_DIRDLL = 11;
  public const int LC_PROP_G_DIRFONTS = 13;
  public const int LC_PROP_G_DIRLNG = 14;
  public const int LC_PROP_G_DIRTPL = 16;
  public const int LC_PROP_G_DIRCFG = 17;
  public const int LC_PROP_G_SAVECFG = 18;
  public const int LC_PROP_G_ICON16 = 20;
  public const int LC_PROP_G_ICON32 = 21;
  public const int LC_PROP_G_RULERBMP = 22;
  public const int LC_PROP_G_DLGVAL = 23;
  public const int LC_PROP_G_PRNUSEBMP = 24;
  public const int LC_PROP_G_PRNBMPFILE = 25;
  public const int LC_PROP_G_PICKBOXSIZE = 26;
  public const int LC_PROP_G_GRIPSIZE = 27;
  public const int LC_PROP_G_GRIPCOLOR = 28;
  public const int LC_PROP_G_PNTPIXSIZE = 29;
  public const int LC_PROP_G_GETDELENT = 30;
  public const int LC_PROP_G_SBARHEIGHT = 31;
  public const int LC_PROP_G_SOLIDBARC = 33;
  public const int LC_PROP_G_BYH = 34;
  public const int LC_PROP_G_PTBUFNEWPTS = 51;
  public const int LC_PROP_G_PTBUFCLR = 52;
  public const int LC_PROP_G_MPGONCLR = 53;
  public const int LC_PROP_G_WF_LEFT = 80;
  public const int LC_PROP_G_WF_BOTTOM = 81;
  public const int LC_PROP_G_WF_WIDTH = 82;
  public const int LC_PROP_G_WF_HEIGHT = 83;
  public const int LC_PROP_G_GBRBMPFILE = 91;
  public const int LC_PROP_G_TEXT_ALIGN = 141;
  public const int LC_PROP_G_TEXT_H = 142;
  public const int LC_PROP_G_TEXT_WS = 143;
  public const int LC_PROP_G_TEXT_CSPACE = 144;
  public const int LC_PROP_G_TEXT_ANG = 145;
  public const int LC_PROP_G_TEXT_OBL = 146;
  public const int LC_PROP_G_TEXT_UPDOWN = 147;
  public const int LC_PROP_G_TEXT_BACK = 148;
  public const int LC_PROP_G_TEXT_FILL = 149;
  public const int LC_PROP_G_TEXT_BORDER = 150;
  public const int LC_PROP_G_BARC_CENTER = 161;
  public const int LC_PROP_G_BARC_ANGLE = 162;
  public const int LC_PROP_G_BARC_BELOW = 163;
  public const int LC_PROP_G_BARC_QZONE = 164;
  public const int LC_PROP_G_BARC_CHSUM = 165;
  public const int LC_PROP_G_BARC_ECL = 166;
  public const int LC_PROP_G_BARC_INVERT = 167;
  public const int LC_PROP_G_BARC_WRATIO = 168;
  public const int LC_PROP_G_BARC_LINEW = 169;
  public const int LC_PROP_G_TOPO_MODE = 181;
  public const int LC_PROP_G_TOPO_PD = 182;
  public const int LC_PROP_G_TOPO_PS = 183;
  public const int LC_PROP_G_TOPO_SIZE = 184;
  public const int LC_PROP_G_TOPO_ZMIN = 185;
  public const int LC_PROP_G_TOPO_ZRANGE = 186;
  public const int LC_PROP_G_TOPO_ZMAX = 187;
  public const int LC_PROP_WND_ID = 301;
  public const int LC_PROP_WND_WIDTH = 302;
  public const int LC_PROP_WND_HEIGHT = 303;
  public const int LC_PROP_WND_PIXELSIZE = 304;
  public const int LC_PROP_WND_CURSORX = 305;
  public const int LC_PROP_WND_CURX = 305;
  public const int LC_PROP_WND_CURSORY = 306;
  public const int LC_PROP_WND_CURY = 306;
  public const int LC_PROP_WND_CURLEF = 307;
  public const int LC_PROP_WND_CURBOT = 308;
  public const int LC_PROP_WND_CURRIG = 309;
  public const int LC_PROP_WND_CURTOP = 310;
  public const int LC_PROP_WND_XMIN = 311;
  public const int LC_PROP_WND_YMIN = 312;
  public const int LC_PROP_WND_XMAX = 313;
  public const int LC_PROP_WND_YMAX = 314;
  public const int LC_PROP_WND_XCEN = 315;
  public const int LC_PROP_WND_YCEN = 316;
  public const int LC_PROP_WND_DX = 317;
  public const int LC_PROP_WND_DY = 318;
  public const int LC_PROP_WND_RULERS = 320;
  public const int LC_PROP_WND_SELECT = 321;
  public const int LC_PROP_WND_SELBYRECT = 322;
  public const int LC_PROP_WND_VIEWBLOCK = 323;
  public const int LC_PROP_WND_DRW = 324;
  public const int LC_PROP_WND_HWND = 325;
  public const int LC_PROP_WND_HASFOCUS = 326;
  public const int LC_PROP_WND_WORKFIELD = 327;
  public const int LC_PROP_WND_CLRHIDE = 328;
  public const int LC_PROP_WND_JUMPLINES = 329;
  public const int LC_PROP_WND_COLORBG = 330;
  public const int LC_PROP_WND_COLORCURSOR = 331;
  public const int LC_PROP_WND_COLORFORE = 332;
  public const int LC_PROP_WND_COLORINFBG = 333;
  public const int LC_PROP_WND_COLORINFBORD = 334;
  public const int LC_PROP_WND_COLORINFTEXT = 335;
  public const int LC_PROP_WND_CURSORSYS = 338;
  public const int LC_PROP_WND_CURSORARROW = 338;
  public const int LC_PROP_WND_CURSORCROSS = 339;
  public const int LC_PROP_WND_CURSORSIZE = 340;
  public const int LC_PROP_WND_COORDS = 341;
  public const int LC_PROP_WND_LWMODE = 345;
  public const int LC_PROP_WND_LWSCALE = 346;
  public const int LC_PROP_WND_BREAKPOINTS = 347;
  public const int LC_PROP_WND_BREAKPTNUMS = 348;
  public const int LC_PROP_WND_ALPHABLEND = 350;
  public const int LC_PROP_WND_STDBLKFRAME = 351;
  public const int LC_PROP_WND_SIZE = 352;
  public const int LC_PROP_WND_DTIME = 353;
  public const int LC_PROP_WND_CAMTIME = 354;
  public const int LC_PROP_WND_DRAWPAPER = 355;
  public const int LC_PROP_WND_FROZEN = 356;
  public const int LC_PROP_WND_CMDENT1 = 357;
  public const int LC_PROP_WND_COMMAND = 369;
  public const int LC_PROP_WND_GRIDSNAP = 370;
  public const int LC_PROP_WND_GRIDSHOW = 371;
  public const int LC_PROP_WND_GRIDDX = 372;
  public const int LC_PROP_WND_GRIDDY = 373;
  public const int LC_PROP_WND_GRIDX0 = 374;
  public const int LC_PROP_WND_GRIDY0 = 375;
  public const int LC_PROP_WND_GRIDBOLDX = 376;
  public const int LC_PROP_WND_GRIDBOLDY = 377;
  public const int LC_PROP_WND_GRIDCOLOR = 378;
  public const int LC_PROP_WND_GRIDDOTTED = 379;
  public const int LC_PROP_WND_GRIDCOLOR2 = 380;
  public const int LC_PROP_WND_GRIDDOTTED2 = 381;
  public const int LC_PROP_WND_PANSTEP = 390;
  public const int LC_PROP_WND_PANLW = 391;
  public const int LC_PROP_WND_PANIMAGE = 392;
  public const int LC_PROP_WND_PANFILL = 393;
  public const int LC_PROP_WND_PANPIXSZ = 394;
  public const int LC_PROP_WND_MEASCOLORPNT = 400;
  public const int LC_PROP_WND_MEASCOLORLINE = 401;
  public const int LC_PROP_WND_MEASLINESIZE = 402;
  public const int LC_PROP_WND_MEASFONTSIZE = 403;
  public const int LC_PROP_WND_MEASFILLAREA = 404;
  public const int LC_PROP_WND_GBRNLAYERS = 421;
  public const int LC_PROP_WND_GBRCLAYER = 422;
  public const int LC_PROP_WND_GBRFILENAME = 423;
  public const int LC_PROP_WND_XLINEANG = 424;
  public const int LC_PROP_FONT_FILENAME = 601;
  public const int LC_PROP_FONT_NAME = 602;
  public const int LC_PROP_FONT_LCF = 603;
  public const int LC_PROP_FONT_HEIGHT = 604;
  public const int LC_PROP_FONT_FILLED = 605;
  public const int LC_PROP_FONT_TTF = 606;
  public const int LC_PROP_FONT_NCHARS = 607;
  public const int LC_PROP_MPGON_XMIN = 631;
  public const int LC_PROP_MPGON_YMIN = 632;
  public const int LC_PROP_MPGON_XMAX = 633;
  public const int LC_PROP_MPGON_YMAX = 634;
  public const int LC_PROP_MPGON_XCEN = 635;
  public const int LC_PROP_MPGON_YCEN = 636;
  public const int LC_PROP_MPGON_W = 637;
  public const int LC_PROP_MPGON_H = 638;
  public const int LC_PROP_TIN_FILENAME = 1831;
  public const int LC_PROP_TIN_EMBEDDED = 1832;
  public const int LC_PROP_TIN_XMIN = 1835;
  public const int LC_PROP_TIN_XMAX = 1836;
  public const int LC_PROP_TIN_YMIN = 1837;
  public const int LC_PROP_TIN_YMAX = 1838;
  public const int LC_PROP_TIN_ZMIN = 1839;
  public const int LC_PROP_TIN_ZMAX = 1840;
  public const int LC_PROP_TIN_DX = 1841;
  public const int LC_PROP_TIN_DY = 1842;
  public const int LC_PROP_TIN_DZ = 1843;
  public const int LC_PROP_TIN_NPOINTS = 1844;
  public const int LC_PROP_TIN_NTRIANS = 1845;
  public const int LC_PROP_TIN_VIEWPT = 1851;
  public const int LC_PROP_TIN_VIEWPTN = 1852;
  public const int LC_PROP_TIN_VIEWPTI = 1853;
  public const int LC_PROP_TIN_VIEWPTZ = 1854;
  public const int LC_PROP_TIN_VIEWTR = 1855;
  public const int LC_PROP_TIN_VIEWTRF = 1856;
  public const int LC_PROP_TIN_VIEWTRI = 1857;
  public const int LC_PROP_TIN_VIEWTRV = 1858;
  public const int LC_PROP_TIN_VIEWISO = 1859;
  public const int LC_PROP_TIN_COLPNT = 1860;
  public const int LC_PROP_TIN_COLTR = 1861;
  public const int LC_PROP_TIN_COLTRI = 1862;
  public const int LC_PROP_TIN_COLTRV = 1863;
  public const int LC_PROP_TIN_COLISO = 1864;
  public const int LC_PROP_TIN_COLISOB = 1865;
  public const int LC_PROP_TIN_ISOSTEP = 1870;
  public const int LC_PROP_TIN_ISOBOLD = 1871;
  public const int LC_PROP_TIN_ISOBASE = 1872;
  public const int LC_PROP_GRID_XMIN = 1882;
  public const int LC_PROP_GRID_XMAX = 1883;
  public const int LC_PROP_GRID_YMIN = 1884;
  public const int LC_PROP_GRID_YMAX = 1885;
  public const int LC_PROP_GRID_W = 1886;
  public const int LC_PROP_GRID_H = 1887;
  public const int LC_PROP_GRID_NCELLX = 1888;
  public const int LC_PROP_GRID_NCELLY = 1889;
  public const int LC_PROP_CMD_OBJ = 2001;
  public const int LC_PROP_CMD_ID = 2002;
  public const int LC_PROP_CMD_STEP = 2003;
  public const int LC_PROP_CMD_LCWND = 2004;
  public const int LC_PROP_CMD_HWND = 2005;
  public const int LC_PROP_CMD_CURSORCROSS = 2006;
  public const int LC_PROP_DRW_UID = 3001;
  public const int LC_PROP_DRW_FILENAME = 3002;
  public const int LC_PROP_DRW_DESCR = 3003;
  public const int LC_PROP_DRW_COMMENT = 3003;
  public const int LC_PROP_DRW_READONLY = 3004;
  public const int LC_PROP_DRW_DIRTY = 3005;
  public const int LC_PROP_DRW_IDMAX = 3006;
  public const int LC_PROP_DRW_RESOLARC = 3008;
  public const int LC_PROP_DRW_RESOLSPLINE = 3009;
  public const int LC_PROP_DRW_RESOLTEXT = 3010;
  public const int LC_PROP_DRW_SYNCZOOM = 3011;
  public const int LC_PROP_DRW_LOCKSEL = 3012;
  public const int LC_PROP_DRW_WF_LEFT = 3051;
  public const int LC_PROP_DRW_WF_BOTTOM = 3052;
  public const int LC_PROP_DRW_WF_WIDTH = 3053;
  public const int LC_PROP_DRW_WF_HEIGHT = 3054;
  public const int LC_PROP_DRW_WF_HIDE = 3055;
  public const int LC_PROP_DRW_WF_NUMCRECTS = 3056;
  public const int LC_PROP_DRW_WF_COLOR = 3057;
  public const int LC_PROP_DRW_WF_COLORCR = 3058;
  public const int LC_PROP_DRW_WF_TEXTSIZE = 3059;
  public const int LC_PROP_DRW_COLOR = 3101;
  public const int LC_PROP_DRW_COLORBYLAYER = 3102;
  public const int LC_PROP_DRW_COLORBYBLOCK = 3103;
  public const int LC_PROP_DRW_COLORI = 3104;
  public const int LC_PROP_DRW_COLORT = 3105;
  public const int LC_PROP_DRW_FCOLOR = 3106;
  public const int LC_PROP_DRW_FCOLORBYLAYER = 3107;
  public const int LC_PROP_DRW_FCOLORBYBLOCK = 3108;
  public const int LC_PROP_DRW_FCOLORI = 3109;
  public const int LC_PROP_DRW_FCOLORT = 3110;
  public const int LC_PROP_DRW_COLORBACKM = 3111;
  public const int LC_PROP_DRW_COLORBACKP = 3112;
  public const int LC_PROP_DRW_COLORFOREM = 3113;
  public const int LC_PROP_DRW_COLORFOREP = 3114;
  public const int LC_PROP_DRW_COLORCURSORM = 3115;
  public const int LC_PROP_DRW_COLORCURSORP = 3116;
  public const int LC_PROP_DRW_COLORPAPER = 3117;
  public const int LC_PROP_DRW_HASALPHABLEND = 3118;
  public const int LC_PROP_DRW_LAYER = 3131;
  public const int LC_PROP_DRW_LINETYPE = 3132;
  public const int LC_PROP_DRW_TEXTSTYLE = 3133;
  public const int LC_PROP_DRW_DIMSTYLE = 3134;
  public const int LC_PROP_DRW_PNTSTYLE = 3135;
  public const int LC_PROP_DRW_MLSTYLE = 3136;
  public const int LC_PROP_DRW_BLOCK = 3137;
  public const int LC_PROP_DRW_VISBLOCK = 3138;
  public const int LC_PROP_DRW_FILLING = 3139;
  public const int LC_PROP_DRW_BARTYPE = 3150;
  public const int LC_PROP_DRW_LWMODE = 3151;
  public const int LC_PROP_DRW_LWSCALE = 3152;
  public const int LC_PROP_DRW_LWIDTH = 3153;
  public const int LC_PROP_DRW_LWDEFAULT = 3154;
  public const int LC_PROP_DRW_LTSCALE = 3155;
  public const int LC_PROP_DRW_BLOCK_MODEL = 3170;
  public const int LC_PROP_DRW_LAYER_0 = 3171;
  public const int LC_PROP_DRW_LINETYPE_CONT = 3172;
  public const int LC_PROP_DRW_LINETYPE_BYLAY = 3173;
  public const int LC_PROP_DRW_LINETYPE_BYBLK = 3174;
  public const int LC_PROP_DRW_TEXTSTYLE_STD = 3175;
  public const int LC_PROP_DRW_TSTYLE_STD = 3175;
  public const int LC_PROP_DRW_PNTSTYLE_STD = 3176;
  public const int LC_PROP_DRW_DIMSTYLE_STD = 3177;
  public const int LC_PROP_DRW_MLSTYLE_STD = 3178;
  public const int LC_PROP_DRW_XDATASIZE = 3201;
  public const int LC_PROP_DRW_XDATA = 3202;
  public const int LC_PROP_DRW_INT0 = 3210;
  public const int LC_PROP_DRW_INT1 = 3211;
  public const int LC_PROP_DRW_INT2 = 3212;
  public const int LC_PROP_DRW_INT3 = 3213;
  public const int LC_PROP_DRW_INT4 = 3214;
  public const int LC_PROP_DRW_INT5 = 3215;
  public const int LC_PROP_DRW_INT6 = 3216;
  public const int LC_PROP_DRW_INT7 = 3217;
  public const int LC_PROP_DRW_INT8 = 3218;
  public const int LC_PROP_DRW_INT9 = 3219;
  public const int LC_PROP_DRW_FLOAT0 = 3220;
  public const int LC_PROP_DRW_FLOAT1 = 3221;
  public const int LC_PROP_DRW_FLOAT2 = 3222;
  public const int LC_PROP_DRW_FLOAT3 = 3223;
  public const int LC_PROP_DRW_FLOAT4 = 3224;
  public const int LC_PROP_DRW_FLOAT5 = 3225;
  public const int LC_PROP_DRW_FLOAT6 = 3226;
  public const int LC_PROP_DRW_FLOAT7 = 3227;
  public const int LC_PROP_DRW_FLOAT8 = 3228;
  public const int LC_PROP_DRW_FLOAT9 = 3229;
  public const int LC_PROP_DRW_STR0 = 3230;
  public const int LC_PROP_DRW_STR1 = 3231;
  public const int LC_PROP_DRW_STR2 = 3232;
  public const int LC_PROP_DRW_STR3 = 3233;
  public const int LC_PROP_DRW_STR4 = 3234;
  public const int LC_PROP_DRW_STR5 = 3235;
  public const int LC_PROP_DRW_STR6 = 3236;
  public const int LC_PROP_DRW_STR7 = 3237;
  public const int LC_PROP_DRW_STR8 = 3238;
  public const int LC_PROP_DRW_STR9 = 3239;
  public const int LC_PROP_TABLE_ID = 4001;
  public const int LC_PROP_TABLE_NAME = 4002;
  public const int LC_PROP_TABLE_DESC = 4003;
  public const int LC_PROP_TABLE_DESCR = 4003;
  public const int LC_PROP_TABLE_DRW = 4004;
  public const int LC_PROP_TABLE_DELETED = 4005;
  public const int LC_PROP_TABLE_ODHANDLE = 4010;
  public const int LC_PROP_TABLE_TYPE = 4011;
  public const int LC_PROP_TABLE_PRIORITY = 4012;
  public const int LC_PROP_TABLE_NREFS = 4013;
  public const int LC_PROP_TABLE_XDATASIZE = 4051;
  public const int LC_PROP_TABLE_XDATA = 4052;
  public const int LC_PROP_TABLE_XSTR = 4053;
  public const int LC_PROP_TABLE_INT0 = 4060;
  public const int LC_PROP_TABLE_INT1 = 4061;
  public const int LC_PROP_TABLE_INT2 = 4062;
  public const int LC_PROP_TABLE_INT3 = 4063;
  public const int LC_PROP_TABLE_INT4 = 4064;
  public const int LC_PROP_TABLE_FLOAT0 = 4070;
  public const int LC_PROP_TABLE_FLOAT1 = 4071;
  public const int LC_PROP_TABLE_FLOAT2 = 4072;
  public const int LC_PROP_TABLE_FLOAT3 = 4073;
  public const int LC_PROP_TABLE_FLOAT4 = 4074;
  public const int LC_PROP_LAYER_ID = 4001;
  public const int LC_PROP_LAYER_NAME = 4002;
  public const int LC_PROP_LAYER_DESC = 4003;
  public const int LC_PROP_LAYER_DESCR = 4003;
  public const int LC_PROP_LAYER_DRW = 4004;
  public const int LC_PROP_LAYER_DELETED = 4005;
  public const int LC_PROP_LAYER_COLOR = 4101;
  public const int LC_PROP_LAYER_COLORI = 4102;
  public const int LC_PROP_LAYER_COLORT = 4103;
  public const int LC_PROP_LAYER_FCOLOR = 4104;
  public const int LC_PROP_LAYER_FCOLORI = 4105;
  public const int LC_PROP_LAYER_FCOLORT = 4106;
  public const int LC_PROP_LAYER_LINETYPE = 4111;
  public const int LC_PROP_LAYER_LWEIGHT = 4112;
  public const int LC_PROP_LAYER_LWIDTH = 4112;
  public const int LC_PROP_LAYER_LOCKED = 4113;
  public const int LC_PROP_LAYER_NOPRINT = 4114;
  public const int LC_PROP_LAYER_VISIBLE = 4115;
  public const int LC_PROP_LAYER_0 = 4116;
  public const int LC_PROP_LAYER_NODLG = 4117;
  public const int LC_PROP_LINETYPE_ID = 4001;
  public const int LC_PROP_LINETYPE_NAME = 4002;
  public const int LC_PROP_LINETYPE_DESC = 4003;
  public const int LC_PROP_LINETYPE_DESCR = 4003;
  public const int LC_PROP_LINETYPE_DRW = 4004;
  public const int LC_PROP_LINETYPE_DELETED = 4005;
  public const int LC_PROP_LINETYPE_DATA = 4145;
  public const int LC_PROP_LINETYPE_SCALE = 4146;
  public const int LC_PROP_LINETYPE_CONTINUOUS = 4147;
  public const int LC_PROP_LINETYPE_BYLAYER = 4148;
  public const int LC_PROP_LINETYPE_BYBLOCK = 4149;
  public const int LC_PROP_LINETYPE_STD = 4150;
  public const int LC_PROP_LINETYPE_PATLEN = 4151;
  public const int LC_PROP_LINETYPE_NELEM = 4153;
  public const int LC_PROP_LINETYPE_IELEM = 4154;
  public const int LC_PROP_LTELEM_LEN = 4155;
  public const int LC_PROP_LTELEM_COMPLEX = 4156;
  public const int LC_PROP_LTELEM_SHAPE = 4157;
  public const int LC_PROP_LTELEM_TEXT = 4158;
  public const int LC_PROP_LTELEM_STYLE = 4159;
  public const int LC_PROP_LTELEM_FONTNAME = 4160;
  public const int LC_PROP_LTELEM_SCALE = 4161;
  public const int LC_PROP_LTELEM_ANGLE = 4162;
  public const int LC_PROP_LTELEM_ABSANGLE = 4163;
  public const int LC_PROP_LTELEM_X = 4164;
  public const int LC_PROP_LTELEM_Y = 4165;
  public const int LC_PROP_TSTYLE_ID = 4001;
  public const int LC_PROP_TSTYLE_NAME = 4002;
  public const int LC_PROP_TSTYLE_DESC = 4003;
  public const int LC_PROP_TSTYLE_DESCR = 4003;
  public const int LC_PROP_TSTYLE_DRW = 4004;
  public const int LC_PROP_TSTYLE_DELETED = 4005;
  public const int LC_PROP_TSTYLE_FONT = 4175;
  public const int LC_PROP_TSTYLE_HFONT = 4176;
  public const int LC_PROP_TSTYLE_HEIGHT = 4177;
  public const int LC_PROP_TSTYLE_WSCALE = 4178;
  public const int LC_PROP_TSTYLE_OBLIQUE = 4179;
  public const int LC_PROP_TSTYLE_ANGLE = 4180;
  public const int LC_PROP_TSTYLE_ALIGN = 4181;
  public const int LC_PROP_TSTYLE_UPDOWN = 4182;
  public const int LC_PROP_TSTYLE_BACKWARD = 4183;
  public const int LC_PROP_TSTYLE_LINESPACE = 4184;
  public const int LC_PROP_TSTYLE_CHARSPACE = 4185;
  public const int LC_PROP_TSTYLE_STANDARD = 4186;
  public const int LC_PROP_TSTYLE_SHAPES = 4187;
  public const int LC_PROP_TSTYLE_WINFONT = 4188;
  public const int LC_PROP_TSTYLE_BOLD = 4189;
  public const int LC_PROP_TSTYLE_ITALIC = 4190;
  public const int LC_PROP_TSTYLE_UNDERLINE = 4191;
  public const int LC_PROP_TSTYLE_STRIKEOUT = 4192;
  public const int LC_PROP_TSTYLE_SOLID = 4193;
  public const int LC_PROP_DIMST_ID = 4001;
  public const int LC_PROP_DIMST_NAME = 4002;
  public const int LC_PROP_DIMST_DESC = 4003;
  public const int LC_PROP_DIMST_DESCR = 4003;
  public const int LC_PROP_DIMST_DRW = 4004;
  public const int LC_PROP_DIMST_DELETED = 4005;
  public const int LC_PROP_DIMST_STANDARD = 4205;
  public const int LC_PROP_DIMST_ADEC = 4211;
  public const int LC_PROP_DIMST_ASZ = 4212;
  public const int LC_PROP_DIMST_AUNIT = 4213;
  public const int LC_PROP_DIMST_AZIN = 4214;
  public const int LC_PROP_DIMST_BLK1 = 4215;
  public const int LC_PROP_DIMST_BLK2 = 4216;
  public const int LC_PROP_DIMST_CEN = 4217;
  public const int LC_PROP_DIMST_CLRD = 4218;
  public const int LC_PROP_DIMST_CLRE = 4219;
  public const int LC_PROP_DIMST_CLRT = 4220;
  public const int LC_PROP_DIMST_DEC = 4221;
  public const int LC_PROP_DIMST_DSEP = 4222;
  public const int LC_PROP_DIMST_EXE = 4223;
  public const int LC_PROP_DIMST_EXO = 4224;
  public const int LC_PROP_DIMST_GAP = 4225;
  public const int LC_PROP_DIMST_LDRBLK = 4226;
  public const int LC_PROP_DIMST_LFAC = 4227;
  public const int LC_PROP_DIMST_LWD = 4228;
  public const int LC_PROP_DIMST_LWE = 4229;
  public const int LC_PROP_DIMST_POST = 4230;
  public const int LC_PROP_DIMST_RND = 4231;
  public const int LC_PROP_DIMST_SCALE = 4232;
  public const int LC_PROP_DIMST_TAD = 4233;
  public const int LC_PROP_DIMST_TIH = 4234;
  public const int LC_PROP_DIMST_TXT = 4235;
  public const int LC_PROP_DIMST_TXSTY = 4236;
  public const int LC_PROP_DIMST_TSTYLE = 4236;
  public const int LC_PROP_DIMST_LUNIT = 4237;
  public const int LC_PROP_DIMST_ZIN = 4238;
  public const int LC_PROP_PSTYLE_ID = 4001;
  public const int LC_PROP_PSTYLE_NAME = 4002;
  public const int LC_PROP_PSTYLE_DESC = 4003;
  public const int LC_PROP_PSTYLE_DESCR = 4003;
  public const int LC_PROP_PSTYLE_DRW = 4004;
  public const int LC_PROP_PSTYLE_DELETED = 4005;
  public const int LC_PROP_PSTYLE_STANDARD = 4265;
  public const int LC_PROP_PSTYLE_BLOCK = 4266;
  public const int LC_PROP_PSTYLE_BSCALE = 4267;
  public const int LC_PROP_PSTYLE_TSTYLE = 4268;
  public const int LC_PROP_PSTYLE_TH = 4269;
  public const int LC_PROP_PSTYLE_TWS = 4270;
  public const int LC_PROP_PSTYLE_PTMODE = 4271;
  public const int LC_PROP_PSTYLE_PTSIZE = 4272;
  public const int LC_PROP_PSTYLE_SNAP = 4273;
  public const int LC_PROP_PSTYLE_FIXED = 4274;
  public const int LC_PROP_MLSTYLE_ID = 4001;
  public const int LC_PROP_MLSTYLE_NAME = 4002;
  public const int LC_PROP_MLSTYLE_DESC = 4003;
  public const int LC_PROP_MLSTYLE_DESCR = 4003;
  public const int LC_PROP_MLSTYLE_DRW = 4004;
  public const int LC_PROP_MLSTYLE_DELETED = 4005;
  public const int LC_PROP_MLSTYLE_STANDARD = 4281;
  public const int LC_PROP_MLSTYLE_JOINTS = 4282;
  public const int LC_PROP_MLSTYLE_STARTLINE = 4283;
  public const int LC_PROP_MLSTYLE_STARTARC = 4284;
  public const int LC_PROP_MLSTYLE_ENDLINE = 4285;
  public const int LC_PROP_MLSTYLE_ENDARC = 4286;
  public const int LC_PROP_MLSTYLE_NLINES = 4287;
  public const int LC_PROP_MLSTYLE_ILINE = 4288;
  public const int LC_PROP_MLSTYLE_OFFSET = 4289;
  public const int LC_PROP_MLSTYLE_LTYPE = 4290;
  public const int LC_PROP_MLSTYLE_COLOR = 4291;
  public const int LC_PROP_IMAGE_ID = 4001;
  public const int LC_PROP_IMAGE_NAME = 4002;
  public const int LC_PROP_IMAGE_DESC = 4003;
  public const int LC_PROP_IMAGE_DESCR = 4003;
  public const int LC_PROP_IMAGE_DRW = 4004;
  public const int LC_PROP_IMAGE_DELETED = 4005;
  public const int LC_PROP_IMAGE_FILENAME = 4401;
  public const int LC_PROP_IMAGE_SIZE = 4402;
  public const int LC_PROP_IMAGE_WPIX = 4403;
  public const int LC_PROP_IMAGE_W = 4404;
  public const int LC_PROP_IMAGE_HPIX = 4405;
  public const int LC_PROP_IMAGE_H = 4406;
  public const int LC_PROP_IMAGE_CBIT = 4407;
  public const int LC_PROP_IMAGE_RGB = 4408;
  public const int LC_PROP_IMAGE_EMBEDDED = 4409;
  public const int LC_PROP_IMAGE_CREATED = 4410;
  public const int LC_PROP_IMAGE_COLORS = 4411;
  public const int LC_PROP_IMAGE_BITS = 4412;
  public const int LC_PROP_IMAGE_DIB = 4413;
  public const int LC_PROP_IMAGE_TRANSPARENT = 4414;
  public const int LC_PROP_IMAGE_TRANCOLOR = 4415;
  public const int LC_PROP_FILL_ID = 4001;
  public const int LC_PROP_FILL_NAME = 4002;
  public const int LC_PROP_FILL_DESC = 4003;
  public const int LC_PROP_FILL_DESCR = 4003;
  public const int LC_PROP_FILL_DRW = 4004;
  public const int LC_PROP_FILL_DELETED = 4005;
  public const int LC_PROP_FILL_NONE = 4501;
  public const int LC_PROP_FILL_SOLID = 4502;
  public const int LC_PROP_FILL_TYPE = 4503;
  public const int LC_PROP_BLOCK_ID = 4001;
  public const int LC_PROP_BLOCK_NAME = 4002;
  public const int LC_PROP_BLOCK_DESC = 4003;
  public const int LC_PROP_BLOCK_DESCR = 4003;
  public const int LC_PROP_BLOCK_DRW = 4004;
  public const int LC_PROP_BLOCK_DELETED = 4005;
  public const int LC_PROP_BLOCK_X = 4801;
  public const int LC_PROP_BLOCK_Y = 4802;
  public const int LC_PROP_BLOCK_UFSCALING = 4803;
  public const int LC_PROP_BLOCK_UNITS = 4804;
  public const int LC_PROP_BLOCK_UNITSCALE = 4810;
  public const int LC_PROP_BLOCK_MODEL = 4811;
  public const int LC_PROP_BLOCK_PAPER = 4812;
  public const int LC_PROP_BLOCK_LAYOUT = 4813;
  public const int LC_PROP_BLOCK_STANDARD = 4814;
  public const int LC_PROP_BLOCK_LAYOUTNAME = 4815;
  public const int LC_PROP_BLOCK_LAYOUTODHANDLE = 4816;
  public const int LC_PROP_BLOCK_LAYOUTORDER = 4817;
  public const int LC_PROP_BLOCK_HIDDEN = 4818;
  public const int LC_PROP_BLOCK_DIM = 4819;
  public const int LC_PROP_BLOCK_HATCH = 4820;
  public const int LC_PROP_BLOCK_NOBJ = 4821;
  public const int LC_PROP_BLOCK_NENTS = 4821;
  public const int LC_PROP_BLOCK_NSELOBJ = 4822;
  public const int LC_PROP_BLOCK_NSELENTS = 4822;
  public const int LC_PROP_BLOCK_ATTRIBS = 4827;
  public const int LC_PROP_BLOCK_XMIN = 4831;
  public const int LC_PROP_BLOCK_YMIN = 4832;
  public const int LC_PROP_BLOCK_XMAX = 4833;
  public const int LC_PROP_BLOCK_YMAX = 4834;
  public const int LC_PROP_BLOCK_DX = 4835;
  public const int LC_PROP_BLOCK_DY = 4836;
  public const int LC_PROP_BLOCK_VISLEF = 4837;
  public const int LC_PROP_BLOCK_VISBOT = 4838;
  public const int LC_PROP_BLOCK_VISRIG = 4839;
  public const int LC_PROP_BLOCK_VISTOP = 4840;
  public const int LC_PROP_BLOCK_SELXMIN = 4841;
  public const int LC_PROP_BLOCK_SELYMIN = 4842;
  public const int LC_PROP_BLOCK_SELXMAX = 4843;
  public const int LC_PROP_BLOCK_SELYMAX = 4844;
  public const int LC_PROP_PAPER_INCH = 4851;
  public const int LC_PROP_PAPER_X0 = 4852;
  public const int LC_PROP_PAPER_Y0 = 4853;
  public const int LC_PROP_PAPER_SIZE = 4854;
  public const int LC_PROP_PAPER_ORIENT = 4855;
  public const int LC_PROP_PAPER_W = 4856;
  public const int LC_PROP_PAPER_H = 4857;
  public const int LC_PROP_ENT_ID = 5001;
  public const int LC_PROP_ENT_KEY = 5002;
  public const int LC_PROP_ENT_COLOR = 5003;
  public const int LC_PROP_ENT_COLORI = 5004;
  public const int LC_PROP_ENT_COLORT = 5005;
  public const int LC_PROP_ENT_COLORBYLAYER = 5006;
  public const int LC_PROP_ENT_COLORBYBLOCK = 5007;
  public const int LC_PROP_ENT_FILLING = 5018;
  public const int LC_PROP_ENT_FILLED = 5019;
  public const int LC_PROP_ENT_SOLIDFILL = 5021;
  public const int LC_PROP_ENT_FCOLOR = 5008;
  public const int LC_PROP_ENT_FCOLORI = 5009;
  public const int LC_PROP_ENT_FCOLORT = 5010;
  public const int LC_PROP_ENT_FCOLORBYLAYER = 5011;
  public const int LC_PROP_ENT_FCOLORBYBLOCK = 5012;
  public const int LC_PROP_ENT_FALPHA = 5013;
  public const int LC_PROP_ENT_LAYER = 5014;
  public const int LC_PROP_ENT_LINETYPE = 5015;
  public const int LC_PROP_ENT_LTSCALE = 5016;
  public const int LC_PROP_ENT_LWEIGHT = 5017;
  public const int LC_PROP_ENT_LWIDTH = 5017;
  public const int LC_PROP_ENT_BLOCK = 5022;
  public const int LC_PROP_ENT_DRW = 5023;
  public const int LC_PROP_ENT_LOCKED = 5024;
  public const int LC_PROP_ENT_VISIBLE = 5025;
  public const int LC_PROP_ENT_HIDDEN = 5026;
  public const int LC_PROP_ENT_BLINK = 5027;
  public const int LC_PROP_ENT_TYPE = 5028;
  public const int LC_PROP_ENT_DELETED = 5029;
  public const int LC_PROP_ENT_IMMORTAL = 5030;
  public const int LC_PROP_ENT_SELECTED = 5031;
  public const int LC_PROP_ENT_PRIORITY = 5040;
  public const int LC_PROP_ENT_XDATASIZE = 5041;
  public const int LC_PROP_ENT_XDATA = 5042;
  public const int LC_PROP_ENT_XSTR = 5043;
  public const int LC_PROP_ENT_Z = 5045;
  public const int LC_PROP_ENT_XMIN = 5046;
  public const int LC_PROP_ENT_YMIN = 5047;
  public const int LC_PROP_ENT_XMAX = 5048;
  public const int LC_PROP_ENT_YMAX = 5049;
  public const int LC_PROP_POINT_STYLE = 5101;
  public const int LC_PROP_POINT_X = 5102;
  public const int LC_PROP_POINT_Y = 5103;
  public const int LC_PROP_POINT_SIZE = 5104;
  public const int LC_PROP_POINT_MODE = 5105;
  public const int LC_PROP_POINT_BANGLE = 5106;
  public const int LC_PROP_POINT_TDX = 5107;
  public const int LC_PROP_POINT_TDY = 5108;
  public const int LC_PROP_POINT_TANGLE = 5109;
  public const int LC_PROP_POINT_TEXT = 5110;
  public const int LC_PROP_POINT_TEXTLEN = 5111;
  public const int LC_PROP_LINE_X0 = 5121;
  public const int LC_PROP_LINE_Y0 = 5122;
  public const int LC_PROP_LINE_Z0 = 5123;
  public const int LC_PROP_LINE_X1 = 5124;
  public const int LC_PROP_LINE_Y1 = 5125;
  public const int LC_PROP_LINE_Z1 = 5126;
  public const int LC_PROP_LINE_DX = 5127;
  public const int LC_PROP_LINE_DY = 5128;
  public const int LC_PROP_LINE_DZ = 5129;
  public const int LC_PROP_LINE_ANG = 5130;
  public const int LC_PROP_LINE_LEN = 5131;
  public const int LC_PROP_XLINE_X0 = 5141;
  public const int LC_PROP_XLINE_Y0 = 5142;
  public const int LC_PROP_XLINE_ANG = 5144;
  public const int LC_PROP_XLINE_DIRX = 5145;
  public const int LC_PROP_XLINE_DIRY = 5146;
  public const int LC_PROP_XLINE_RAY = 5147;
  public const int LC_PROP_CIRCLE_X = 5201;
  public const int LC_PROP_CIRCLE_Y = 5202;
  public const int LC_PROP_CIRCLE_R = 5204;
  public const int LC_PROP_CIRCLE_RAD = 5204;
  public const int LC_PROP_CIRCLE_RADIUS = 5204;
  public const int LC_PROP_CIRCLE_DIAM = 5205;
  public const int LC_PROP_CIRCLE_LEN = 5206;
  public const int LC_PROP_CIRCLE_AREA = 5207;
  public const int LC_PROP_CIRCLE_ANG0 = 5208;
  public const int LC_PROP_CIRCLE_DIRCW = 5209;
  public const int LC_PROP_CIRCLE_RESOL = 5210;
  public const int LC_PROP_CIRC_X = 5201;
  public const int LC_PROP_CIRC_Y = 5202;
  public const int LC_PROP_CIRC_R = 5204;
  public const int LC_PROP_CIRC_RAD = 5204;
  public const int LC_PROP_CIRC_RADIUS = 5204;
  public const int LC_PROP_CIRC_DIAM = 5205;
  public const int LC_PROP_CIRC_LEN = 5206;
  public const int LC_PROP_CIRC_AREA = 5207;
  public const int LC_PROP_CIRC_ANG0 = 5208;
  public const int LC_PROP_CIRC_DIRCW = 5209;
  public const int LC_PROP_CIRC_RESOL = 5210;
  public const int LC_PROP_ARC_X = 5231;
  public const int LC_PROP_ARC_Y = 5232;
  public const int LC_PROP_ARC_R = 5234;
  public const int LC_PROP_ARC_RAD = 5234;
  public const int LC_PROP_ARC_RADIUS = 5234;
  public const int LC_PROP_ARC_ANG0 = 5235;
  public const int LC_PROP_ARC_ANGARC = 5236;
  public const int LC_PROP_ARC_ANGEND = 5237;
  public const int LC_PROP_ARC_X0 = 5238;
  public const int LC_PROP_ARC_Y0 = 5239;
  public const int LC_PROP_ARC_XEND = 5241;
  public const int LC_PROP_ARC_YEND = 5242;
  public const int LC_PROP_ARC_LEN = 5244;
  public const int LC_PROP_ARC_CHLEN = 5245;
  public const int LC_PROP_ARC_AREA = 5246;
  public const int LC_PROP_ARC_CCW = 5247;
  public const int LC_PROP_ARC_SECTOR = 5250;
  public const int LC_PROP_ARC_RESOL = 5251;
  public const int LC_PROP_ELL_X = 5261;
  public const int LC_PROP_ELL_Y = 5262;
  public const int LC_PROP_ELL_R1 = 5264;
  public const int LC_PROP_ELL_R2 = 5265;
  public const int LC_PROP_ELL_RATIO = 5266;
  public const int LC_PROP_ELL_ANGLE = 5267;
  public const int LC_PROP_ELL_ANG0 = 5268;
  public const int LC_PROP_ELL_ANGARC = 5269;
  public const int LC_PROP_ELL_ANGEND = 5270;
  public const int LC_PROP_ELL_X0 = 5271;
  public const int LC_PROP_ELL_Y0 = 5272;
  public const int LC_PROP_ELL_XEND = 5273;
  public const int LC_PROP_ELL_YEND = 5274;
  public const int LC_PROP_ELL_LEN = 5276;
  public const int LC_PROP_ELL_AREA = 5277;
  public const int LC_PROP_ELL_FULL = 5278;
  public const int LC_PROP_ELL_CCW = 5279;
  public const int LC_PROP_ELL_SECTOR = 5282;
  public const int LC_PROP_ELL_RESOL = 5283;
  public const int LC_PROP_PLINE_FIT = 5301;
  public const int LC_PROP_PLINE_NVERS = 5302;
  public const int LC_PROP_PLINE_NPATHS = 5303;
  public const int LC_PROP_PLINE_WIDTH = 5305;
  public const int LC_PROP_PLINE_RADIUS = 5306;
  public const int LC_PROP_PLINE_CHAMFER = 5307;
  public const int LC_PROP_PLINE_LEN = 5308;
  public const int LC_PROP_PLINE_AREA = 5309;
  public const int LC_PROP_PLINE_CLOSED = 5310;
  public const int LC_PROP_PLINE_HASANG0 = 5313;
  public const int LC_PROP_PLINE_ANG0 = 5314;
  public const int LC_PROP_PLINE_HASANG2 = 5315;
  public const int LC_PROP_PLINE_ANG2 = 5316;
  public const int LC_PROP_PLINE_CW = 5317;
  public const int LC_PROP_PLINE_CCW = 5318;
  public const int LC_PROP_PLINE_Z = 5319;
  public const int LC_PROP_PLINE_CONSTZ = 5320;
  public const int LC_PROP_PLINE_RESOLA = 5321;
  public const int LC_PROP_PLINE_RESOLS = 5322;
  public const int LC_PROP_MLINE_STYLE = 5351;
  public const int LC_PROP_MLINE_JUST = 5352;
  public const int LC_PROP_MLINE_SCALE = 5353;
  public const int LC_PROP_MLINE_NVERS = 5354;
  public const int LC_PROP_MLINE_CLOSED = 5355;
  public const int LC_PROP_MLINE_FIT = 5356;
  public const int LC_PROP_MLINE_LEN = 5357;
  public const int LC_PROP_MLINE_AREA = 5358;
  public const int LC_PROP_RECT_X = 5371;
  public const int LC_PROP_RECT_Y = 5372;
  public const int LC_PROP_RECT_W = 5374;
  public const int LC_PROP_RECT_H = 5375;
  public const int LC_PROP_RECT_ANGLE = 5376;
  public const int LC_PROP_RECT_R = 5377;
  public const int LC_PROP_RECT_RAD = 5377;
  public const int LC_PROP_RECT_RADIUS = 5377;
  public const int LC_PROP_RECT_CHAMFER = 5378;
  public const int LC_PROP_RECT_DIRCW = 5379;
  public const int LC_PROP_RECT_LEN = 5381;
  public const int LC_PROP_RECT_AREA = 5382;
  public const int LC_PROP_RECT_RESOL = 5383;
  public const int LC_PROP_CLRECT_ID = 5390;
  public const int LC_PROP_CLRECT_NAME = 5391;
  public const int LC_PROP_CLRECT_X = 5392;
  public const int LC_PROP_CLRECT_Y = 5393;
  public const int LC_PROP_CLRECT_W = 5394;
  public const int LC_PROP_CLRECT_H = 5395;
  public const int LC_PROP_CLRECT_ANGLE = 5396;
  public const int LC_PROP_CLRECT_LEN = 5398;
  public const int LC_PROP_CLRECT_AREA = 5399;
  public const int LC_PROP_TEXT_STYLE = 5401;
  public const int LC_PROP_TEXT_STR = 5402;
  public const int LC_PROP_TEXT_STRT = 5403;
  public const int LC_PROP_TEXT_LEN = 5404;
  public const int LC_PROP_TEXT_ALIGN = 5405;
  public const int LC_PROP_TEXT_X = 5406;
  public const int LC_PROP_TEXT_Y = 5407;
  public const int LC_PROP_TEXT_H = 5411;
  public const int LC_PROP_TEXT_WSCALE = 5412;
  public const int LC_PROP_TEXT_ANGLE = 5413;
  public const int LC_PROP_TEXT_OBLIQUE = 5414;
  public const int LC_PROP_TEXT_CHARSPACE = 5415;
  public const int LC_PROP_TEXT_WRECT = 5416;
  public const int LC_PROP_TEXT_X0 = 5417;
  public const int LC_PROP_TEXT_Y0 = 5418;
  public const int LC_PROP_TEXT_XFIT = 5419;
  public const int LC_PROP_TEXT_YFIT = 5420;
  public const int LC_PROP_TEXT_UPDOWN = 5421;
  public const int LC_PROP_TEXT_BACKWARD = 5422;
  public const int LC_PROP_TEXT_RESOL = 5423;
  public const int LC_PROP_MTEXT_STYLE = 5451;
  public const int LC_PROP_MTEXT_STR = 5452;
  public const int LC_PROP_MTEXT_LEN = 5453;
  public const int LC_PROP_MTEXT_ALIGN = 5454;
  public const int LC_PROP_MTEXT_X = 5455;
  public const int LC_PROP_MTEXT_Y = 5456;
  public const int LC_PROP_MTEXT_H = 5458;
  public const int LC_PROP_MTEXT_WSCALE = 5459;
  public const int LC_PROP_MTEXT_ANGLE = 5460;
  public const int LC_PROP_MTEXT_OBLIQUE = 5461;
  public const int LC_PROP_MTEXT_WRECT = 5462;
  public const int LC_PROP_MTEXT_HRECT = 5463;
  public const int LC_PROP_MTEXT_WRAPWIDTH = 5464;
  public const int LC_PROP_MTEXT_LINESPACE = 5465;
  public const int LC_PROP_MTEXT_CHARSPACE = 5466;
  public const int LC_PROP_MTEXT_MIRROR = 5467;
  public const int LC_PROP_MTEXT_RESOL = 5468;
  public const int LC_PROP_ATEXT_STYLE = 5481;
  public const int LC_PROP_ATEXT_STR = 5482;
  public const int LC_PROP_ATEXT_STRT = 5483;
  public const int LC_PROP_ATEXT_LEN = 5484;
  public const int LC_PROP_ATEXT_X = 5485;
  public const int LC_PROP_ATEXT_Y = 5486;
  public const int LC_PROP_ATEXT_R = 5487;
  public const int LC_PROP_ATEXT_RAD = 5487;
  public const int LC_PROP_ATEXT_RADIUS = 5487;
  public const int LC_PROP_ATEXT_ANGLE = 5488;
  public const int LC_PROP_ATEXT_ANGSTA = 5489;
  public const int LC_PROP_ATEXT_ANGEND = 5490;
  public const int LC_PROP_ATEXT_CW = 5491;
  public const int LC_PROP_ATEXT_H = 5492;
  public const int LC_PROP_ATEXT_WSCALE = 5493;
  public const int LC_PROP_ATEXT_CHARSPACE = 5494;
  public const int LC_PROP_ATEXT_ALIGN = 5495;
  public const int LC_PROP_ATEXT_RESOL = 5496;
  public const int LC_PROP_ATT_MODE = 5501;
  public const int LC_PROP_ATT_TSTYLE = 5502;
  public const int LC_PROP_ATT_TAG = 5503;
  public const int LC_PROP_ATT_PROMPT = 5504;
  public const int LC_PROP_ATT_DEFVAL = 5505;
  public const int LC_PROP_ATT_ALIGN = 5506;
  public const int LC_PROP_ATT_X = 5507;
  public const int LC_PROP_ATT_Y = 5508;
  public const int LC_PROP_ATT_Z = 5509;
  public const int LC_PROP_ATT_H = 5510;
  public const int LC_PROP_ATT_WSCALE = 5511;
  public const int LC_PROP_ATT_ANGLE = 5512;
  public const int LC_PROP_ATT_OBLIQUE = 5513;
  public const int LC_PROP_ATT_X0 = 5514;
  public const int LC_PROP_ATT_Y0 = 5515;
  public const int LC_PROP_ATT_XFIT = 5516;
  public const int LC_PROP_ATT_YFIT = 5517;
  public const int LC_PROP_ATT_UPDOWN = 5518;
  public const int LC_PROP_ATT_BACKWARD = 5519;
  public const int LC_PROP_ATT_POS = 5520;
  public const int LC_PROP_ATT_FIT = 5521;
  public const int LC_PROP_BLKREF_BLOCK = 5531;
  public const int LC_PROP_BLKREF_X = 5532;
  public const int LC_PROP_BLKREF_Y = 5533;
  public const int LC_PROP_BLKREF_SCALE = 5535;
  public const int LC_PROP_BLKREF_SCX = 5536;
  public const int LC_PROP_BLKREF_SCY = 5537;
  public const int LC_PROP_BLKREF_UFSCALE = 5539;
  public const int LC_PROP_BLKREF_ANGLE = 5540;
  public const int LC_PROP_BLKREF_ARNX = 5541;
  public const int LC_PROP_BLKREF_ARDX = 5542;
  public const int LC_PROP_BLKREF_ARNY = 5543;
  public const int LC_PROP_BLKREF_ARDY = 5544;
  public const int LC_PROP_BLKREF_ARANG = 5545;
  public const int LC_PROP_BLKREF_ATTRIBS = 5546;
  public const int LC_PROP_IMGREF_IMAGE = 5551;
  public const int LC_PROP_IMGREF_XC = 5554;
  public const int LC_PROP_IMGREF_YC = 5555;
  public const int LC_PROP_IMGREF_W = 5556;
  public const int LC_PROP_IMGREF_H = 5557;
  public const int LC_PROP_IMGREF_WPIX = 5558;
  public const int LC_PROP_IMGREF_HPIX = 5559;
  public const int LC_PROP_IMGREF_SCALE = 5560;
  public const int LC_PROP_IMGREF_PIXELSIZE = 5560;
  public const int LC_PROP_IMGREF_ANGLE = 5563;
  public const int LC_PROP_IMGREF_BORDER = 5565;
  public const int LC_PROP_IMGREF_TRANSP = 5566;
  public const int LC_PROP_IMGREF_TRCOLOR = 5567;
  public const int LC_PROP_IMGREF_TRALPHA = 5568;
  public const int LC_PROP_IMGREF_GREY = 5569;
  public const int LC_PROP_IMGREF_FLIPHOR = 5570;
  public const int LC_PROP_IMGREF_FLIPVER = 5571;
  public const int LC_PROP_IMGREF_PATH = 5573;
  public const int LC_PROP_ECW_FILENAME = 5581;
  public const int LC_PROP_ECW_LOADED = 5582;
  public const int LC_PROP_ECW_XMIN = 5583;
  public const int LC_PROP_ECW_YMIN = 5584;
  public const int LC_PROP_ECW_XMAX = 5585;
  public const int LC_PROP_ECW_YMAX = 5586;
  public const int LC_PROP_ECW_W = 5587;
  public const int LC_PROP_ECW_H = 5588;
  public const int LC_PROP_ECW_WPIX = 5589;
  public const int LC_PROP_ECW_HPIX = 5590;
  public const int LC_PROP_ECW_CBIT = 5591;
  public const int LC_PROP_ECW_SCALEX = 5592;
  public const int LC_PROP_ECW_SCALEY = 5593;
  public const int LC_PROP_ECW_BORDER = 5594;
  public const int LC_PROP_HATCH_NAME = 5631;
  public const int LC_PROP_HATCH_PATTERN = 5632;
  public const int LC_PROP_HATCH_SCALE = 5633;
  public const int LC_PROP_HATCH_ANGLE = 5634;
  public const int LC_PROP_HATCH_SIZE = 5635;
  public const int LC_PROP_HATCH_ASSOC = 5636;
  public const int LC_PROP_HATCH_SOLID = 5637;
  public const int LC_PROP_HATCH_CUSTOM = 5638;
  public const int LC_PROP_HATCH_NPT = 5639;
  public const int LC_PROP_HATCH_NLOOP = 5640;
  public const int LC_PROP_HATCH_NHPL = 5641;
  public const int LC_PROP_HATCH_IHPL = 5642;
  public const int LC_PROP_HPL_ANGLE = 5651;
  public const int LC_PROP_HPL_X0 = 5652;
  public const int LC_PROP_HPL_Y0 = 5653;
  public const int LC_PROP_HPL_DX = 5654;
  public const int LC_PROP_HPL_DY = 5655;
  public const int LC_PROP_HPL_NDASH = 5656;
  public const int LC_PROP_HPL_DASH1 = 5657;
  public const int LC_PROP_HPL_DASH2 = 5658;
  public const int LC_PROP_HPL_DASH3 = 5659;
  public const int LC_PROP_HPL_DASH4 = 5660;
  public const int LC_PROP_HPL_DASH5 = 5661;
  public const int LC_PROP_HPL_DASH6 = 5662;
  public const int LC_PROP_HPL_DASH7 = 5663;
  public const int LC_PROP_HPL_DASH8 = 5664;
  public const int LC_PROP_VPORT_LEF = 5703;
  public const int LC_PROP_VPORT_BOT = 5704;
  public const int LC_PROP_VPORT_RIG = 5705;
  public const int LC_PROP_VPORT_TOP = 5706;
  public const int LC_PROP_VPORT_BORDER = 5707;
  public const int LC_PROP_VPORT_W = 5711;
  public const int LC_PROP_VPORT_H = 5712;
  public const int LC_PROP_VPORT_VX = 5713;
  public const int LC_PROP_VPORT_VY = 5714;
  public const int LC_PROP_VPORT_VSCALE = 5715;
  public const int LC_PROP_VPORT_VANGLE = 5716;
  public const int LC_PROP_VPORT_FIXSCALE = 5717;
  public const int LC_PROP_BARC_X = 5751;
  public const int LC_PROP_BARC_Y = 5752;
  public const int LC_PROP_BARC_W = 5753;
  public const int LC_PROP_BARC_H = 5754;
  public const int LC_PROP_BARC_ANG = 5755;
  public const int LC_PROP_BARC_TYPE = 5756;
  public const int LC_PROP_BARC_CODE = 5757;
  public const int LC_PROP_BARC_TEXT = 5757;
  public const int LC_PROP_BARC_CHECKSUM = 5758;
  public const int LC_PROP_BARC_NCHARS = 5759;
  public const int LC_PROP_BARC_NPADS = 5760;
  public const int LC_PROP_BARC_NARSIZE = 5761;
  public const int LC_PROP_BARC_WIDERATIO = 5762;
  public const int LC_PROP_BARC_QZONE = 5764;
  public const int LC_PROP_BARC_OFFSET = 5765;
  public const int LC_PROP_BARC_INVERT = 5766;
  public const int LC_PROP_BARC_SHOWTEXT = 5767;
  public const int LC_PROP_BARC_TSTYLE = 5768;
  public const int LC_PROP_BARC_TEXTH = 5769;
  public const int LC_PROP_BARC_TEXTW = 5770;
  public const int LC_PROP_BARC_TEXTCS = 5771;
  public const int LC_PROP_BARC_TEXTALIGN = 5773;
  public const int LC_PROP_BARC_TEXTRES = 5774;
  public const int LC_PROP_BARC_ECLEVEL = 5775;
  public const int LC_PROP_BARC_MASKPAT = 5776;
  public const int LC_PROP_BARC_QRVER = 5777;
  public const int LC_PROP_BARC_DMSIZE = 5778;
  public const int LC_PROP_BARC_NBARS = 5779;
  public const int LC_PROP_BARC_NMODX = 5779;
  public const int LC_PROP_BARC_NMODY = 5780;
  public const int LC_PROP_ARR_X0 = 5801;
  public const int LC_PROP_ARR_Y0 = 5802;
  public const int LC_PROP_ARR_X1 = 5803;
  public const int LC_PROP_ARR_Y1 = 5804;
  public const int LC_PROP_ARR_TIME = 5805;
  public const int LC_PROP_ARR_SHARP = 5806;
  public const int LC_PROP_SPIR_X = 5821;
  public const int LC_PROP_SPIR_Y = 5822;
  public const int LC_PROP_SPIR_R = 5823;
  public const int LC_PROP_SPIR_RADIUS = 5823;
  public const int LC_PROP_SPIR_R2 = 5824;
  public const int LC_PROP_SPIR_RATIO = 5825;
  public const int LC_PROP_SPIR_ANGLE = 5826;
  public const int LC_PROP_SPIR_TURNS = 5827;
  public const int LC_PROP_SPIR_DIRCW = 5829;
  public const int LC_PROP_SPIR_CLOSED = 5830;
  public const int LC_PROP_SPIR_DSTEP = 5831;
  public const int LC_PROP_SPIR_RESOL = 5832;
  public const int LC_PROP_DIM_STYLE = 6001;
  public const int LC_PROP_DIM_MEAS = 6003;
  public const int LC_PROP_DIM_TEXT = 6004;
  public const int LC_PROP_DIMANG_STYLE = 6001;
  public const int LC_PROP_DIMANG_MEAS = 6003;
  public const int LC_PROP_DIMANG_TEXT = 6004;
  public const int LC_PROP_DIMALI_STYLE = 6001;
  public const int LC_PROP_DIMALI_MEAS = 6003;
  public const int LC_PROP_DIMALI_TEXT = 6004;
  public const int LC_PROP_DIMDIA_STYLE = 6001;
  public const int LC_PROP_DIMDIA_MEAS = 6003;
  public const int LC_PROP_DIMDIA_TEXT = 6004;
  public const int LC_PROP_DIMRAD_STYLE = 6001;
  public const int LC_PROP_DIMRAD_MEAS = 6003;
  public const int LC_PROP_DIMRAD_TEXT = 6004;
  public const int LC_PROP_DIMORD_STYLE = 6001;
  public const int LC_PROP_DIMORD_MEAS = 6003;
  public const int LC_PROP_DIMORD_TEXT = 6004;
  public const int LC_PROP_DIMROT_STYLE = 6001;
  public const int LC_PROP_DIMROT_MEAS = 6003;
  public const int LC_PROP_DIMROT_TEXT = 6004;
  public const int LC_PROP_DIMLIN_STYLE = 6001;
  public const int LC_PROP_DIMLIN_MEAS = 6003;
  public const int LC_PROP_DIMLIN_TEXT = 6004;
  public const int LC_PROP_DIMANG_3PNT = 6011;
  public const int LC_PROP_DIMANG_2LINE = 6012;
  public const int LC_PROP_DIMANG_CPX = 6013;
  public const int LC_PROP_DIMANG_CPY = 6014;
  public const int LC_PROP_DIMANG_DP1X = 6015;
  public const int LC_PROP_DIMANG_DP1Y = 6016;
  public const int LC_PROP_DIMANG_DP2X = 6017;
  public const int LC_PROP_DIMANG_DP2Y = 6018;
  public const int LC_PROP_DIMANG_L1P1X = 6021;
  public const int LC_PROP_DIMANG_L1P1Y = 6022;
  public const int LC_PROP_DIMANG_L1P2X = 6023;
  public const int LC_PROP_DIMANG_L1P2Y = 6024;
  public const int LC_PROP_DIMANG_DP3X = 6023;
  public const int LC_PROP_DIMANG_DP3Y = 6024;
  public const int LC_PROP_DIMANG_L2P1X = 6025;
  public const int LC_PROP_DIMANG_L2P1Y = 6026;
  public const int LC_PROP_DIMANG_L2P2X = 6027;
  public const int LC_PROP_DIMANG_L2P2Y = 6028;
  public const int LC_PROP_DIMANG_DP4X = 6027;
  public const int LC_PROP_DIMANG_DP4Y = 6028;
  public const int LC_PROP_DIMANG_APX = 6029;
  public const int LC_PROP_DIMANG_APY = 6030;
  public const int LC_PROP_DIMANG_EXT1 = 6031;
  public const int LC_PROP_DIMANG_EXT2 = 6032;
  public const int LC_PROP_DIMANG_RAD = 6033;
  public const int LC_PROP_DIMANG_TPOS = 6034;
  public const int LC_PROP_DIMALI_DP1X = 6051;
  public const int LC_PROP_DIMALI_DP1Y = 6052;
  public const int LC_PROP_DIMALI_DP2X = 6053;
  public const int LC_PROP_DIMALI_DP2Y = 6054;
  public const int LC_PROP_DIMALI_TPX = 6055;
  public const int LC_PROP_DIMALI_TPY = 6056;
  public const int LC_PROP_DIMDIA_CPX = 6071;
  public const int LC_PROP_DIMDIA_CPY = 6072;
  public const int LC_PROP_DIMDIA_RPX = 6073;
  public const int LC_PROP_DIMDIA_RPY = 6074;
  public const int LC_PROP_DIMDIA_FPX = 6075;
  public const int LC_PROP_DIMDIA_FPY = 6076;
  public const int LC_PROP_DIMDIA_TPX = 6077;
  public const int LC_PROP_DIMDIA_TPY = 6078;
  public const int LC_PROP_DIMRAD_CPX = 6086;
  public const int LC_PROP_DIMRAD_CPY = 6087;
  public const int LC_PROP_DIMRAD_RPX = 6088;
  public const int LC_PROP_DIMRAD_RPY = 6089;
  public const int LC_PROP_DIMRAD_TPX = 6090;
  public const int LC_PROP_DIMRAD_TPY = 6091;
  public const int LC_PROP_DIMORD_XORD = 6101;
  public const int LC_PROP_DIMORD_DPX = 6102;
  public const int LC_PROP_DIMORD_DPY = 6103;
  public const int LC_PROP_DIMORD_TPX = 6104;
  public const int LC_PROP_DIMORD_TPY = 6105;
  public const int LC_PROP_DIMROT_ANGLE = 6121;
  public const int LC_PROP_DIMROT_DP1X = 6122;
  public const int LC_PROP_DIMROT_DP1Y = 6123;
  public const int LC_PROP_DIMROT_DP2X = 6124;
  public const int LC_PROP_DIMROT_DP2Y = 6125;
  public const int LC_PROP_DIMROT_TPX = 6126;
  public const int LC_PROP_DIMROT_TPY = 6127;
  public const int LC_PROP_DIMLIN_ANGLE = 6121;
  public const int LC_PROP_DIMLIN_DP1X = 6122;
  public const int LC_PROP_DIMLIN_DP1Y = 6123;
  public const int LC_PROP_DIMLIN_DP2X = 6124;
  public const int LC_PROP_DIMLIN_DP2Y = 6125;
  public const int LC_PROP_DIMLIN_TPX = 6126;
  public const int LC_PROP_DIMLIN_TPY = 6127;
  public const int LC_PROP_LEADER_STYLE = 6202;
  public const int LC_PROP_LEADER_TEXT = 6203;
  public const int LC_PROP_LEADER_ALIGN = 6204;
  public const int LC_PROP_LEADER_TPX = 6205;
  public const int LC_PROP_LEADER_TPY = 6206;
  public const int LC_PROP_LEADER_APX = 6207;
  public const int LC_PROP_LEADER_APY = 6208;
  public const int LC_PROP_LEADER_P1X = 6209;
  public const int LC_PROP_LEADER_P1Y = 6210;
  public const int LC_PROP_LEADER_P0X = 6211;
  public const int LC_PROP_LEADER_P0Y = 6212;
  public const int LC_PROP_LEADER_LDIST = 6213;
  public const int LC_PROP_LEADER_VERT = 6214;
  public const int LC_PROP_LEADER_CORNER = 6215;
  public const int LC_PROP_LEADER_TBW = 6216;
  public const int LC_PROP_LEADER_TBH = 6217;
  public const int LC_PROP_RPLAN_LEN = 6301;
  public const int LC_PROP_RPLAN_MARKARC = 6302;
  public const int LC_PROP_RPLAN_MARKSIZE = 6303;
  public const int LC_PROP_RPLAN_NVERS = 6311;
  public const int LC_PROP_RPLAN_IVER = 6312;
  public const int LC_PROP_RPVER_X = 6313;
  public const int LC_PROP_RPVER_Y = 6314;
  public const int LC_PROP_RPVER_ANGLE = 6315;
  public const int LC_PROP_RPVER_DIRANG = 6316;
  public const int LC_PROP_RPVER_R = 6317;
  public const int LC_PROP_RPVER_L1 = 6318;
  public const int LC_PROP_RPVER_L2 = 6319;
  public const int LC_PROP_RPVER_ANGL1 = 6320;
  public const int LC_PROP_RPVER_ANGARC = 6321;
  public const int LC_PROP_RPVER_ANGL2 = 6322;
  public const int LC_PROP_RPVER_BISEC = 6323;
  public const int LC_PROP_RPVER_ARCLEN = 6324;
  public const int LC_PROP_RPVER_CURLEN = 6325;
  public const int LC_PROP_RPVER_LINE1 = 6326;
  public const int LC_PROP_RPVER_T1 = 6327;
  public const int LC_PROP_RPVER_T2 = 6328;
  public const int LC_PROP_RPVER_LINE2 = 6329;
  public const int LC_PROP_RPVER_DIST1 = 6330;
  public const int LC_PROP_RPVER_DIST2 = 6331;
  public const int LC_PROP_VER_X = 10001;
  public const int LC_PROP_VER_Y = 10002;
  public const int LC_PROP_VER_Z = 10003;
  public const int LC_PROP_VER_ENDPATH = 10005;
  public const int LC_PROP_VER_FIX = 10006;
  public const int LC_PROP_VER_RADIUS = 10007;
  public const int LC_PROP_VER_WEIGHT = 10008;
  public const int LC_PROP_VER_INDEX = 10009;
  public const int LC_PROP_VER_FIRST = 10010;
  public const int LC_PROP_VER_LAST = 10011;
  public const int LC_PROP_VER_W0 = 10012;
  public const int LC_PROP_VER_W1 = 10013;
  public const int LC_PROP_VER_SEGDX = 10014;
  public const int LC_PROP_VER_SEGDY = 10015;
  public const int LC_PROP_VER_SEGANG = 10016;
  public const int LC_PROP_VER_SEGLEN = 10017;
  public const int LC_PROP_VER_BULGE = 10021;
  public const int LC_PROP_VER_SEGARCANG = 10022;
  public const int LC_PROP_VER_SEGARCH = 10023;
  public const int LC_PROP_VER_SEGARCLEN = 10024;
  public const int LC_PROP_VER_SEGARCRAD = 10025;
  public const int LC_PROP_PROPWND_ENABLE = 11002;
  public const int LC_PROP_PROPWND_DIVCOEF = 11003;
  public const int LC_PROP_EVENT_TYPE = 12001;
  public const int LC_PROP_EVENT_APP = 12002;
  public const int LC_PROP_EVENT_WND = 12003;
  public const int LC_PROP_EVENT_DRW = 12004;
  public const int LC_PROP_EVENT_BLOCK = 12005;
  public const int LC_PROP_EVENT_ENTITY = 12006;
  public const int LC_PROP_EVENT_HCMD = 12007;
  public const int LC_PROP_EVENT_HDC = 12008;
  public const int LC_PROP_EVENT_INT1 = 12009;
  public const int LC_PROP_EVENT_INT2 = 12010;
  public const int LC_PROP_EVENT_INT3 = 12011;
  public const int LC_PROP_EVENT_INT4 = 12012;
  public const int LC_PROP_EVENT_INT5 = 12013;
  public const int LC_PROP_EVENT_INT6 = 12014;
  public const int LC_PROP_EVENT_FLOAT1 = 12015;
  public const int LC_PROP_EVENT_FLOAT2 = 12016;
  public const int LC_PROP_EVENT_FLOAT3 = 12017;
  public const int LC_PROP_EVENT_FLOAT4 = 12018;
  public const int LC_PROP_EVENT_FLOAT5 = 12019;
  public const int LC_PROP_EVENT_FLOAT6 = 12020;
  public const int LC_PROP_EVENT_STR1 = 12021;
  public const int LC_PROP_EVENT_STR2 = 12022;
  public const int LC_EVENT_HELP = 101;
  public const int LC_EVENT_PAINT = 102;
  public const int LC_EVENT_WNDVIEW = 103;
  public const int LC_EVENT_WNDTAB = 104;
  public const int LC_EVENT_MOUSEMOVE = 105;
  public const int LC_EVENT_LBDOWN = 106;
  public const int LC_EVENT_LBUP = 107;
  public const int LC_EVENT_LBDBLCLK = 108;
  public const int LC_EVENT_RBDOWN = 109;
  public const int LC_EVENT_RBUP = 110;
  public const int LC_EVENT_KEYDOWN = 111;
  public const int LC_EVENT_VIEWBLOCK = 112;
  public const int LC_EVENT_EXTENTS = 113;
  public const int LC_EVENT_SNAP = 114;
  public const int LC_EVENT_FILE = 131;
  public const int LC_EVENT_ADDENTITY = 132;
  public const int LC_EVENT_ENTPROP = 133;
  public const int LC_EVENT_DRWPROP = 134;
  public const int LC_EVENT_SELECT = 135;
  public const int LC_EVENT_SEL1ENT = 161;
  public const int LC_EVENT_SELENTS = 162;
  public const int LC_EVENT_GRIPMOVE = 163;
  public const int LC_EVENT_GRIPDRAG = 164;
  public const int LC_EVENT_GRIPPAINT = 165;
  public const int LC_EVENT_DRAWCURSOR = 166;
  public const int LC_EVENT_RULERCORNER = 167;
  public const int LC_EVENT_ADDSTR = 168;
  public const int LC_EVENT_ADDCMD = 169;
  public const int LC_EVENT_ALPHABLEND = 170;
  public const int LC_EVENT_CMDCREATE = 201;
  public const int LC_EVENT_CMDDESTROY = 202;
  public const int LC_EVENT_CMDSTART = 203;
  public const int LC_EVENT_CMDEND = 204;
  public const int LC_EVENT_CMDLBDOWN = 205;
  public const int LC_EVENT_CMDLBUP = 206;
  public const int LC_EVENT_CMDRBDOWN = 207;
  public const int LC_EVENT_CMDRBUP = 208;
  public const int LC_EVENT_CMDMOUSEMOVE = 209;
  public const int LC_EVENT_CMDPAINT = 210;
  public const int LC_EVENT_CMDSNAP = 211;
  public const int LC_EVENT_CMD1 = 212;
  public const int LC_EVENT_LAYERS = 303;

  [DllImport("Litecad64.dll", EntryPoint="lcEventReturnCode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern void EventReturnCode(int code);

  [DllImport("Litecad64.dll", EntryPoint="lcEventEnable", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern void EventEnable(bool b);

  [DllImport("Litecad64.dll", EntryPoint="lcEventDefProc", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern void EventDefProc(int hEvent, int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcInitialize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Initialize(F_LCEVENT pFunc, int hApp, int RegCode);

  [DllImport("Litecad64.dll", EntryPoint="lcUninitialize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Uninitialize(bool bSaveConfig);

  [DllImport("Litecad64.dll", EntryPoint="lcStrAdd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StrAdd(string szTag, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcStrSet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StrSet(string szTag, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcStrGet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern string StrGet(string szTag);

  [DllImport("Litecad64.dll", EntryPoint="lcStrFileLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StrFileLoad(string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcStrFileSave", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StrFileSave(string szFileName, string szLanguage);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetBool", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropGetBool(int hObject, int idProp);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetInt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PropGetInt(int hObject, int idProp);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetFloat", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern double PropGetFloat(int hObject, int idProp);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetStr", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern string PropGetStr(int hObject, int idProp);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetChar", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PropGetChar(int iChar);

  [DllImport("Litecad64.dll", EntryPoint="lcPropGetHandle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PropGetHandle(int hObject, int idProp);

  [DllImport("Litecad64.dll", EntryPoint="lcPropPutBool", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropPutBool(int hObject, int idProp, bool bValue);

  [DllImport("Litecad64.dll", EntryPoint="lcPropPutInt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropPutInt(int hObject, int idProp, int Value);

  [DllImport("Litecad64.dll", EntryPoint="lcPropPutFloat", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropPutFloat(int hObject, int idProp, double Value);

  [DllImport("Litecad64.dll", EntryPoint="lcPropPutStr", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropPutStr(int hObject, int idProp, string szValue);

  [DllImport("Litecad64.dll", EntryPoint="lcPropPutHandle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropPutHandle(int hObject, int idProp, int hValue);

  [DllImport("Litecad64.dll", EntryPoint="lcCreateWindow", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int CreateWindow(IntPtr hWndParent, int Style);

  [DllImport("Litecad64.dll", EntryPoint="lcDeleteWindow", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DeleteWindow(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndResize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndResize(int hLcWnd, int Left, int Top, int Width, int Height);

  [DllImport("Litecad64.dll", EntryPoint="lcWndRedraw", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndRedraw(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndSetFocus", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndSetFocus(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndSetExtents", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndSetExtents(int hLcWnd, double Xmin, double Ymin, double Xmax, double Ymax);

  [DllImport("Litecad64.dll", EntryPoint="lcWndZoomRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndZoomRect(int hLcWnd, double Left, double Bottom, double Right, double Top);

  [DllImport("Litecad64.dll", EntryPoint="lcWndZoomScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndZoomScale(int hLcWnd, double Scal);

  [DllImport("Litecad64.dll", EntryPoint="lcWndZoomMove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndZoomMove(int hLcWnd, double DX, double DY);

  [DllImport("Litecad64.dll", EntryPoint="lcWndGetCursorCoord", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndGetCursorCoord(int hLcWnd, out int pXwin, out int pYwin, out double pXdrw, out double pYdrw);

  [DllImport("Litecad64.dll", EntryPoint="lcWndExeCommand", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndExeCommand(int hLcWnd, int Command, int CmdParam);

  [DllImport("Litecad64.dll", EntryPoint="lcWndOnClose", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndOnClose(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndSetBlock", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndSetBlock(int hLcWnd, int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcWndSetProps", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndSetProps(int hLcWnd, int hPropWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndToRaster", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WndToRaster(int hLcWnd, int ImgW, int ImgH, out IntPtr pBuffer, int ResizeFilter);

  [DllImport("Litecad64.dll", EntryPoint="lcWndGetEntByPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WndGetEntByPoint(int hLcWnd, int Xwin, int Ywin);

  [DllImport("Litecad64.dll", EntryPoint="lcWndGetEntByPoint2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WndGetEntByPoint2(int hLcWnd, double X, double Y, double Delta);

  [DllImport("Litecad64.dll", EntryPoint="lcWndGetEntsByRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WndGetEntsByRect(int hLcWnd, double Lef, double Bot, double Rig, double Top, bool bCross, int nMaxEnts);

  [DllImport("Litecad64.dll", EntryPoint="lcWndGetEntity", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WndGetEntity(int iEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcCoordDrwToWnd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CoordDrwToWnd(int hLcWnd, double Xdrw, double Ydrw, out int pXwnd, out int pYwnd);

  [DllImport("Litecad64.dll", EntryPoint="lcCoordWndToDrw", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CoordWndToDrw(int hLcWnd, int Xwnd, int Ywnd, out double pXdrw, out double pYdrw);

  [DllImport("Litecad64.dll", EntryPoint="lcWndTabClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndTabClear(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcWndTabAdd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndTabAdd(int hLcWnd, int TabID, string szLabel, string szTipText, int hObject);

  [DllImport("Litecad64.dll", EntryPoint="lcWndTabSelect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndTabSelect(int hLcWnd, int TabID);

  [DllImport("Litecad64.dll", EntryPoint="lcWndPaperEnable", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndPaperEnable(int hLcWnd, bool bEnable);

  [DllImport("Litecad64.dll", EntryPoint="lcWndPaperSetSize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndPaperSetSize(int hLcWnd, int Size, int Orient);

  [DllImport("Litecad64.dll", EntryPoint="lcWndPaperSetSize2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndPaperSetSize2(int hLcWnd, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcWndPaperSetPos", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WndPaperSetPos(int hLcWnd, double Left, double Bottom);

  [DllImport("Litecad64.dll", EntryPoint="lcGripClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GripClear(int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcGripAdd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GripAdd(int hLcWnd, int hObj, int iGrip, int Typ, double X, double Y, double Ang, double X0, double Y0);

  [DllImport("Litecad64.dll", EntryPoint="lcGripSet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GripSet(int hLcWnd, int hObj, int iGrip, double X, double Y, double Ang, double X0, double Y0);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PenCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_PenCreate(int hLcWnd, int Id, int Color, double Width, int PenStyle);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PenSelect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PenSelect(int hLcWnd, int hPen);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PenSelectID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PenSelectID(int hLcWnd, int IdPen);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_BrushCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_BrushCreate(int hLcWnd, int Id, int Color, int Pattern, int Alpha);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_BrushSelect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_BrushSelect(int hLcWnd, int hBrush);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_BrushSelectID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_BrushSelectID(int hLcWnd, int IdBrush);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawPtbuf", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawPtbuf(int hLcWnd, int hPtbuf, bool bClosed);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawMpgon", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawMpgon(int hLcWnd, int hMpgon, bool bFill, bool bBorder);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawImage", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawImage(int hLcWnd, int hImage, double X, double Y, double PixelSize, int Transp, int TVal, int hPtbuf);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawImage2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawImage2(int hLcWnd, int hImage, double X, double Y, double W, double H, int Transp, int TVal, int hPtbuf);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawText(int hLcWnd, double X, double Y, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawText2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawText2(int hLcWnd, double X1, double Y1, double X2, double Y2, int Align, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawTextBC", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawTextBC(int hLcWnd, int hMpgon, double Gap, double Height, int Align, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawArcText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawArcText(int hLcWnd, string szText, double X, double Y, double Rad, double Ang0, bool bCW, double H, double WScale, int Align);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawHatch", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawHatch(int hLcWnd, int hHatch);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawPoint(int hLcWnd, double X, double Y, int PtMode, double PtSize);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawLine", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawLine(int hLcWnd, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawXline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawXline(int hLcWnd, double X, double Y, double Angle, bool bRay);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawRect(int hLcWnd, double Xc, double Yc, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawRect2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawRect2(int hLcWnd, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawTIN", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawTIN(int hLcWnd, int hTIN);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawGrid", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawGrid(int hLcWnd, int hGrid, bool bDest, int ColLine, int ColNode);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DrawCPrompt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DrawCPrompt(int hLcWnd, int X, int Y, int Align, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_CreatePtbuf", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_CreatePtbuf();

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DeletePtbuf", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DeletePtbuf(int hPtbuf);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufClear(int hPtbuf);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddPoint(int hPtbuf, double X, double Y, double Prm1, double Prm2, int IntPrm);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddPoint2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddPoint2(int hPtbuf, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddPointP", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddPointP(int hPtbuf, double Angle, double Dist);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddLine", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddLine(int hPtbuf, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddLineP", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddLineP(int hPtbuf, double X, double Y, double Angle, double Dist);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddCircle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddCircle(int hPtbuf, double Xc, double Yc, double R, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddCircle2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddCircle2(int hPtbuf, double X1, double Y1, double X2, double Y2, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddCircle3", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddCircle3(int hPtbuf, double X1, double Y1, double X2, double Y2, double X3, double Y3, bool bInside, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArc", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArc(int hPtbuf, double Xc, double Yc, double R, double StartAngle, double ArcAngle, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArc3p", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArc3p(int hPtbuf, double X1, double Y1, double X2, double Y2, double X3, double Y3, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSDE", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSDE(int hPtbuf, double Xs, double Ys, double DirAng, double Xe, double Ye, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSDAR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSDAR(int hPtbuf, double Xs, double Ys, double DirAng, double AngArc, double R, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSER", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSER(int hPtbuf, double Xs, double Ys, double Xe, double Ye, double Radius, bool bClockwise, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSEL", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSEL(int hPtbuf, double Xs, double Ys, double Xe, double Ye, double ArcLen, bool bClockwise, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSEA", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSEA(int hPtbuf, double Xs, double Ys, double Xe, double Ye, double AngArc, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcSEB", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcSEB(int hPtbuf, double Xs, double Ys, double Xe, double Ye, double Bulge, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcCSE", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcCSE(int hPtbuf, double Xc, double Yc, double Xs, double Ys, double Xe, double Ye, bool bClockwise, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcCSA", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcCSA(int hPtbuf, double Xc, double Yc, double Xs, double Ys, double AngArc, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcCSL", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcCSL(int hPtbuf, double Xc, double Yc, double Xs, double Ys, double ChordLen, bool bClockwise, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddArcCRAA", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddArcCRAA(int hPtbuf, double Xc, double Yc, double R, double AngStart, double AngEnd, bool bClockwise, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddEllipse", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddEllipse(int hPtbuf, double Xc, double Yc, double Rmaj, double Rmin, double RotAng, double StartAng, double ArcAng, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddEllipse2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddEllipse2(int hPtbuf, double X1, double Y1, double X2, double Y2, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddRect(int hPtbuf, double Xc, double Yc, double W, double H, double Angle, double R, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddRect2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddRect2(int hPtbuf, double X1, double Y1, double X2, double Y2, double R, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddRect3", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddRect3(int hPtbuf, double X1, double Y1, double X2, double Y2, double W, int Align, double R, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddWline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddWline(int hPtbuf, double X1, double Y1, double X2, double Y2, double W, int Align, bool bArc, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufAddPtbuf", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufAddPtbuf(int hPtbuf, int hPtbuf2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufGetPoint(int hPtbuf, int Mode, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufGetPoint2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufGetPoint2(int hPtbuf, int Mode, out double pX, out double pY, out double pPrm1, out double pPrm2, out int pIntPrm);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufInterpolate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufInterpolate(int hPtbuf, bool bClosed, int hPtbufDest, int Mode, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufMove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufMove(int hPtbuf, double dx, double dy);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufRotate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufRotate(int hPtbuf, double Xc, double Yc, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufScale(int hPtbuf, double Xc, double Yc, double ScaleX, double ScaleY);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufMirror", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufMirror(int hPtbuf, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_PtbufCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_PtbufCopy(int hPtbuf, int hPtbufDest);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_CreateMpgon", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_CreateMpgon();

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_DeleteMpgon", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_DeleteMpgon(int hMpgon);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonClear(int hMpgon);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonAddPgon", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonAddPgon(int hMpgon, int hPtbuf);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonAddText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonAddText(int hMpgon, int hFont, double X, double Y, string szText, int Resol);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonAddBarcode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonAddBarcode(int hMpgon, int BarType, double Xc, double Yc, double Width, double Height, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonMove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonMove(int hMpgon, double dx, double dy);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonRotate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonRotate(int hMpgon, double Xc, double Yc, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonScale(int hMpgon, double Xc, double Yc, double ScaleX, double ScaleY);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonMirror", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonMirror(int hMpgon, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_MpgonCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_MpgonCopy(int hMpgon, int hMpgonDest);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_HatchGen", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_HatchGen(int hMpgon, int hHatch, double Dist, double Angle, double W, double Beamc1, double Beamc2, double StartOff, double EndOff);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageAdd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_ImageAdd(int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageDelete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageDelete(int hImage);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageGetFirst", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_ImageGetFirst();

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageGetNext", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_ImageGetNext(int hImage);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageGetByID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_ImageGetByID(int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageLoad(int hImage, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageCopy(int hImage, int hImageDest);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageCreate(int hImage, int Width, int Height);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageSetPixel", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageSetPixel(int hImage, int X, int Y, int R, int G, int B);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageFlip", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageFlip(int hImage, bool bHor, bool bVert);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageRotate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageRotate(int hImage, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageGray", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageGray(int hImage);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageResize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_ImageResize(int hImage, int NewWidth, int NewHeight, int ResizeFilter);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_ImageGetPtbuf", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_ImageGetPtbuf(int hImage, double RotAngle);

  [DllImport("Litecad64.dll", EntryPoint="lcFontGetFirst", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontGetFirst();

  [DllImport("Litecad64.dll", EntryPoint="lcFontGetNext", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontGetNext(int hFont);

  [DllImport("Litecad64.dll", EntryPoint="lcFontAddRes", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontAddRes(string szFontName, int hModule, int idResource);

  [DllImport("Litecad64.dll", EntryPoint="lcFontAddFile", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontAddFile(string szFontName, string szFilename);

  [DllImport("Litecad64.dll", EntryPoint="lcFontAddBin", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontAddBin(string szFontName, int hData);

  [DllImport("Litecad64.dll", EntryPoint="lcFontGetChar", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int FontGetChar(int hFont, int CharCode);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_FontOpenLC", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_FontOpenLC(string szFontName);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_FontOpenTT", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Paint_FontOpenTT(string szFontName, bool bBold, bool bItalic);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_FontClose", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_FontClose(int hFont);

  [DllImport("Litecad64.dll", EntryPoint="lcPaint_FontSelect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Paint_FontSelect(int hLcWnd, int hFont);

  [DllImport("Litecad64.dll", EntryPoint="lcProgressCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressCreate(int hLcWnd, int W, int H, string szTitle);

  [DllImport("Litecad64.dll", EntryPoint="lcProgressSetText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressSetText(string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcProgressStart", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressStart(int MinVal, int MaxVal);

  [DllImport("Litecad64.dll", EntryPoint="lcProgressSetPos", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressSetPos(int Val);

  [DllImport("Litecad64.dll", EntryPoint="lcProgressInc", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressInc();

  [DllImport("Litecad64.dll", EntryPoint="lcProgressDelete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ProgressDelete();

  [DllImport("Litecad64.dll", EntryPoint="lcQuadCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int QuadCreate();

  [DllImport("Litecad64.dll", EntryPoint="lcQuadDelete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool QuadDelete(int hQuad);

  [DllImport("Litecad64.dll", EntryPoint="lcQuadSet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool QuadSet(int hQuad, double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3);

  [DllImport("Litecad64.dll", EntryPoint="lcQuadTransXYtoUV", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool QuadTransXYtoUV(int hQuad, double X, double Y, out double pU, out double pV);

  [DllImport("Litecad64.dll", EntryPoint="lcQuadTransUVtoXY", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool QuadTransUVtoXY(int hQuad, double U, double V, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcQuadContains", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool QuadContains(int hQuad, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcGridCreate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int GridCreate();

  [DllImport("Litecad64.dll", EntryPoint="lcGridDelete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridDelete(int hGrid);

  [DllImport("Litecad64.dll", EntryPoint="lcGridSet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridSet(int hGrid, double X0, double Y0, double W, double H, int Nx, int Ny);

  [DllImport("Litecad64.dll", EntryPoint="lcGridSetDest", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridSetDest(int hGrid, int Ix, int Iy, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcGridUpdate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridUpdate(int hGrid);

  [DllImport("Litecad64.dll", EntryPoint="lcGridTrans", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridTrans(int hGrid, double X, double Y, out double pXdest, out double pYdest);

  [DllImport("Litecad64.dll", EntryPoint="lcGridGetNode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridGetNode(int hGrid, bool bDest, int Ix, int Iy, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcGridGetCell", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridGetCell(int hGrid, double X, double Y, out int pIx, out int pIy);

  [DllImport("Litecad64.dll", EntryPoint="lcGridSetView", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GridSetView(int hGrid, int Mode, int hLcWnd, int ColLine, int ColNode);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_Create", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int TIN_Create(int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_Delete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool TIN_Delete(int hTIN);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_Load", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool TIN_Load(int hTIN, string szFileName, int hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_GetZ", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool TIN_GetZ(int hTIN, double X, double Y, out double pZ);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_InterLine", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int TIN_InterLine(int hTIN, double X0, double Y0, double X1, double Y1);

  [DllImport("Litecad64.dll", EntryPoint="lcTIN_InterGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool TIN_InterGetPoint(int hTIN, int iPnt, out double pX, out double pY, out double pZ);

  [DllImport("Litecad64.dll", EntryPoint="lcCreateProps", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int CreateProps(IntPtr hWndParent);

  [DllImport("Litecad64.dll", EntryPoint="lcDeleteProps", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DeleteProps(int hPropWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcPropsResize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropsResize(int hPropWnd, int Left, int Top, int Width, int Height);

  [DllImport("Litecad64.dll", EntryPoint="lcPropsUpdate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PropsUpdate(int hPropWnd, bool bSelChanged);

  [DllImport("Litecad64.dll", EntryPoint="lcCreateStatbar", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int CreateStatbar(IntPtr hWndParent);

  [DllImport("Litecad64.dll", EntryPoint="lcDeleteStatbar", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DeleteStatbar(int hStatbar);

  [DllImport("Litecad64.dll", EntryPoint="lcStatbarResize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StatbarResize(int hStatbar, int Left, int Top, int Width, int Height);

  [DllImport("Litecad64.dll", EntryPoint="lcStatbarCell", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StatbarCell(int hStatbar, int Id, int Pos);

  [DllImport("Litecad64.dll", EntryPoint="lcStatbarText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StatbarText(int hStatbar, int Id, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcStatbarRedraw", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool StatbarRedraw(int hStatbar);

  [DllImport("Litecad64.dll", EntryPoint="lcDgGetValue", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DgGetValue(int hWnd, int Lef, int Top, string szTitle, string szPrompt);

  [DllImport("Litecad64.dll", EntryPoint="lcHelp", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Help(string szTopic);

  [DllImport("Litecad64.dll", EntryPoint="lcGetPolarPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern void GetPolarPoint(double x0, double y0, double Angle, double Dist, out double pOutX, out double pOutY);

  [DllImport("Litecad64.dll", EntryPoint="lcGetPolarPrm", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern void GetPolarPrm(double x1, double y1, double x2, double y2, out double pAngle, out double pDist);

  [DllImport("Litecad64.dll", EntryPoint="lcGetClientSize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GetClientSize(IntPtr hWnd, out int pWidth, out int pHeight);

  [DllImport("Litecad64.dll", EntryPoint="lcGetErrorCode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int GetErrorCode();

  [DllImport("Litecad64.dll", EntryPoint="lcGetErrorStr", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern string GetErrorStr();

  [DllImport("Litecad64.dll", EntryPoint="lcGbrLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool GbrLoad(int hLcWnd, string szFileName0);

  [DllImport("Litecad64.dll", EntryPoint="lcCreateCommand", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int CreateCommand(int hLcWnd, int Id, string szName, string szTitle, int hObj);

  [DllImport("Litecad64.dll", EntryPoint="lcCmdExit", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CmdExit(int hCmd);

  [DllImport("Litecad64.dll", EntryPoint="lcCmdCursorText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CmdCursorText(int hCmd, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcCmdMessage", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CmdMessage(int hCmd, string szText, int IconType);

  [DllImport("Litecad64.dll", EntryPoint="lcCmdResetLastPt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool CmdResetLastPt(int hCmd);

  [DllImport("Litecad64.dll", EntryPoint="lcCreateDrawing", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int CreateDrawing();

  [DllImport("Litecad64.dll", EntryPoint="lcDeleteDrawing", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DeleteDrawing(int hDrw);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwNew", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwNew(int hDrw, string szFileName, int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwLoad(int hDrw, string szFileName, int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwLoadMem", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwLoadMem(int hDrw, int hMem, int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwInsert", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwInsert(int hDrw, string szFileName, int Overwrite, int hLcWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwCopy(int hDrw, int hDrwSrc);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwSave", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwSave(int hDrw, string szFileName, bool bBak, int hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwSaveMem", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwSaveMem(int hDrw, int hMem, int MemSize);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddLayer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddLayer(int hDrw, string szName, string szColor, int hLtype, int Lwidth);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddLinetype", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddLinetype(int hDrw, string szName, string szDefinition);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddLinetypeF", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddLinetypeF(int hDrw, string szName, string szFileName, string szLtypeName);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddTextStyle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddTextStyle(int hDrw, string szName, string szFontName, bool bWinFont);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddDimStyle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddDimStyle(int hDrw, string szName);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddMlineStyle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddMlineStyle(int hDrw, string szName);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddPntStyle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddPntStyle(int hDrw, string szName, int hBlock, double BlockScale, int hTStyle, double TextHeight, double TextWidth);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddImage", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddImage(int hDrw, string szName, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddImage2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddImage2(int hDrw, string szName, int Width, int Height, int nBits);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddImage3", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddImage3(int hDrw, string szName, int hMem);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddImageCam", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddImageCam(int hDrw);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlock", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlock(int hDrw, string szName, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlockFromFile", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlockFromFile(int hDrw, string szName, string szFileName, int Overwrite, IntPtr hwParent);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlockFromDrw", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlockFromDrw(int hDrw, string szName, int hDrw2, int Overwrite, IntPtr hwParent);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlockFile", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlockFile(int hDrw, string szName, string szFileName, int Overwrite, IntPtr hwParent);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlockPaper", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlockPaper(int hDrw, string szName, int PaperSize, int Orient, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwAddBlockCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwAddBlockCopy(int hDrw, string szName, int hSrcBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwDeleteObject", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwDeleteObject(int hDrw, int hObject);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwDeleteUnused", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwDeleteUnused(int hDrw, int ObjType);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetFirstObject", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetFirstObject(int hDrw, int ObjType);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetNextObject", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetNextObject(int hDrw, int hObject);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetObjectByID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetObjectByID(int hDrw, int ObjType, int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetObjectByIDH", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetObjectByIDH(int hDrw, int ObjType, string szId);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetObjectByName", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetObjectByName(int hDrw, int ObjType, string szName);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwCountObjects", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwCountObjects(int hDrw, int ObjType);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwSortObjects", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwSortObjects(int hDrw, int ObjType);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetEntByID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetEntByID(int hDrw, int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetEntByIDH", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetEntByIDH(int hDrw, string szId);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwGetEntByKey", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int DrwGetEntByKey(int hDrw, int Key);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwUndoRecord", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwUndoRecord(int hDrw, int Mode);

  [DllImport("Litecad64.dll", EntryPoint="lcDrwUndo", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool DrwUndo(int hDrw, bool bRedo);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSetViewRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSetViewRect(int hBlock, double Xcen, double Ycen, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSetViewRect2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSetViewRect2(int hBlock, double Lef, double Bot, double Rig, double Top);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSetPaperSize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSetPaperSize(int hBlock, int PaperSize, int Orient, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockRasterize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockRasterize(int hBlock, string szFileName, double Xmin, double Ymin, double Xmax, double Ymax, int ImgW, int ImgH);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockRasterizeMem", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockRasterizeMem(int hBlock, int hMem, double Xmin, double Ymin, double Xmax, double Ymax, int ImgW, int ImgH);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockUpdate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockUpdate(int hBlock, bool bUpdEnts, int hNewEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockScale(int hBlock, double Scale);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockClear(int hBlock, int hLayer);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockPurge", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockPurge(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSortEnts", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSortEnts(int hBlock, bool bByLayers, IntPtr hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddPoint(int hBlock, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddPoint2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddPoint2(int hBlock, double X, double Y, int PtMode, double PtSize);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddPointTopo", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddPointTopo(int hBlock, double X, double Y, double Z);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddXline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddXline(int hBlock, double X, double Y, double Angle, bool bRay);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddXline2P", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddXline2P(int hBlock, double X, double Y, double X2, double Y2, bool bRay);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddLine", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddLine(int hBlock, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddLineDir", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddLineDir(int hBlock, double X, double Y, double Angle, double Dist);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddLineTan", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddLineTan(int hBlock, int hEnt1, int hEnt2, int Mode);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddPolyline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddPolyline(int hBlock, int FitType, bool bClosed, bool bFilled);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddSpline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddSpline(int hBlock, bool bClosed, bool bFilled);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddMline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddMline(int hBlock, int FitType, bool bClosed);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddRect(int hBlock, double Xc, double Yc, double Width, double Height, double Angle, bool bFilled);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddRect2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddRect2(int hBlock, double Left, double Bottom, double Width, double Height, double Rad, bool bFilled);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddCircle", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddCircle(int hBlock, double X, double Y, double Radius, bool bFilled);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddArc", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddArc(int hBlock, double X, double Y, double Radius, double StartAngle, double ArcAngle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddArc3P", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddArc3P(int hBlock, double X1, double Y1, double X2, double Y2, double X3, double Y3);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddEllipse", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddEllipse(int hBlock, double X, double Y, double R1, double R2, double RotAngle, double StartAngle, double ArcAngle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddText(int hBlock, string szText, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddText2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddText2(int hBlock, string szText, double X, double Y, int Align, double H, double WScale, double RotAngle, double Oblique);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddText3", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddText3(int hBlock, string szText, double X1, double Y1, double X2, double Y2, int Align, double HW, double Oblique);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddMText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddMText(int hBlock, string szText, double X, double Y, double WrapWidth, int Align, double RotAngle, double H, double WScale);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddArcText", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddArcText(int hBlock, string szText, double X, double Y, double Radius, double StartAngle, bool bClockwise, double H, double WScale, int Align);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddBlockRef", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddBlockRef(int hBlock, int hRefBlock, double X, double Y, double Scal, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddBlockRefID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddBlockRefID(int hBlock, int idRefBlock, double X, double Y, double Scal, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddBlockRefIDH", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddBlockRefIDH(int hBlock, string szIdRefBlock, double X, double Y, double Scal, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddImageRef", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddImageRef(int hBlock, int hImage, double X, double Y, double Width, double Height, bool bBorder);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddHatch", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddHatch(int hBlock, string szFileName, string szPatName, double Scal, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddViewport", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddViewport(int hBlock, double Lef, double Bot, double Width, double Height, double DrwPntX, double DrwPntY, double DrwScale, double DrwAngle);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddFace", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddFace(int hBlock, int Flags, double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddFace4", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddFace4(int hBlock, int Flags, double x0, double y0, double z0, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddLeader", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddLeader(int hBlock, string szText, double Xt, double Yt, double LandDist, double Xa, double Ya, int Attach, int Align);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimLin", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimLin(int hBlock, double X0, double Y0, double X1, double Y1, double Xt, double Yt, double Angle, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimHor", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimHor(int hBlock, double X0, double Y0, double X1, double Y1, double Yt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimVer(int hBlock, double X0, double Y0, double X1, double Y1, double Xt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimAli", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimAli(int hBlock, double X0, double Y0, double X1, double Y1, double Xt, double Yt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimAli2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimAli2(int hBlock, double X0, double Y0, double X1, double Y1, double Dt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimOrd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimOrd(int hBlock, double Xd, double Yd, double Xt, double Yt, bool bX, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimRad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimRad(int hBlock, double Xc, double Yc, double Xr, double Yr, double Xt, double Yt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimRad2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimRad2(int hBlock, double Xc, double Yc, double R, double Angle, double TextOff, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimDia", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimDia(int hBlock, double Xc, double Yc, double Xr, double Yr, double Xt, double Yt, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimDia2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimDia2(int hBlock, double Xc, double Yc, double R, double Angle, double TextOff, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimAng", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimAng(int hBlock, double Xc, double Yc, double X1, double Y1, double X2, double Y2, double Xa, double Ya, double TextPos, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddDimAng2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddDimAng2(int hBlock, double X1, double Y1, double X2, double Y2, double X3, double Y3, double X4, double Y4, double Xa, double Ya, double TextPos, string szText);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddRPlan", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddRPlan(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddMpgon", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockAddMpgon(int hBlock, int hMpgon);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddArrow", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddArrow(int hBlock, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddSpiral", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddSpiral(int hBlock, double Xc, double Yc, double R, double Turns, double AngStep, bool bDirCW);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockAddClone", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockAddClone(int hBlock, int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetFirstEnt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetFirstEnt(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetNextEnt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetNextEnt(int hBlock, int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetLastEnt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetLastEnt(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetPrevEnt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetPrevEnt(int hBlock, int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetEntByID", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetEntByID(int hBlock, int Id);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetEntByIDH", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetEntByIDH(int hBlock, string szId);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetEntByKey", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetEntByKey(int hBlock, int Key);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockUnselect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockUnselect(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelectEnt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelectEnt(int hBlock, int hEntity, bool bSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelErase", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelErase(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelMove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelMove(int hBlock, double dX, double dY, bool bCopy, bool bNewSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelScale(int hBlock, double X0, double Y0, double Scal, bool bCopy, bool bNewSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelRotate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelRotate(int hBlock, double X0, double Y0, double Angle, bool bCopy, bool bNewSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelMirror", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelMirror(int hBlock, double X1, double Y1, double X2, double Y2, bool bCopy, bool bNewSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelExplode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSelExplode(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSelJoin", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockSelJoin(int hBlock, double Delta);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetFirstSel", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetFirstSel(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetNextSel", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int BlockGetNextSel(int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockOrderByLayers", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockOrderByLayers(int hBlock, IntPtr hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockSortTSP", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool BlockSortTSP(int hBlock, int hLayer, IntPtr hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcBlockGetJumpsLen", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern double BlockGetJumpsLen(int hBlock, int hLayer, IntPtr hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcLayerClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool LayerClear(int hLayer, int hBlock);

  [DllImport("Litecad64.dll", EntryPoint="lcEntErase", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntErase(int hEnt, bool bErase);

  [DllImport("Litecad64.dll", EntryPoint="lcEntMove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntMove(int hEnt, double dX, double dY);

  [DllImport("Litecad64.dll", EntryPoint="lcEntScale", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntScale(int hEnt, double X0, double Y0, double Scal);

  [DllImport("Litecad64.dll", EntryPoint="lcEntRotate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntRotate(int hEnt, double X0, double Y0, double Angle);

  [DllImport("Litecad64.dll", EntryPoint="lcEntMirror", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntMirror(int hEnt, double X1, double Y1, double X2, double Y2);

  [DllImport("Litecad64.dll", EntryPoint="lcEntExplode", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntExplode(int hEnt, bool bSelect);

  [DllImport("Litecad64.dll", EntryPoint="lcEntOffset", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntOffset(int hEnt, double Dist);

  [DllImport("Litecad64.dll", EntryPoint="lcEntToTop", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntToTop(int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcEntToBottom", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntToBottom(int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcEntToAbove", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntToAbove(int hEnt, int hEnt2);

  [DllImport("Litecad64.dll", EntryPoint="lcEntToUnder", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntToUnder(int hEnt, int hEnt2);

  [DllImport("Litecad64.dll", EntryPoint="lcEntGetGrip", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntGetGrip(int hEnt, int iGrip, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcEntPutGrip", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntPutGrip(int hEnt, int iGrip, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcEntUpdate", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntUpdate(int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcEntCopyBase", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool EntCopyBase(int hEnt, int hEntFrom);

  [DllImport("Litecad64.dll", EntryPoint="lcIntersection", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int Intersection(int hEnt, int hEnt2);

  [DllImport("Litecad64.dll", EntryPoint="lcInterGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool InterGetPoint(int iPoint, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineAddVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineAddVer(int hPline, int hVer, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineAddVer2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineAddVer2(int hPline, int hVer, double X, double Y, double Param, double W0, double W1);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineAddVerDir", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineAddVerDir(int hPline, int hVer, double Ang, double Length);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineEnd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PlineEnd(int hPline);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineDeleteVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PlineDeleteVer(int hPline, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetFirstVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetFirstVer(int hPline);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetNextVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetNextVer(int hPline, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetLastVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetLastVer(int hPline);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetPrevVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetPrevVer(int hPline, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetVer(int hPline, int Index);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetVerPt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetVerPt(int hPline, double X, double Y, double Delta);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetSeg", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineGetSeg(int hPline, double X, double Y, double Delta);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineReverse", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PlineReverse(int hPline);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineSimple", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PlineSimple(int hPline);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineContainPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int PlineContainPoint(int hPline, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcPlineGetRoundPrm", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool PlineGetRoundPrm(int hPline, int hVer, out double px0, out double py0, out double pBulge, out double px1, out double py1);

  [DllImport("Litecad64.dll", EntryPoint="lcXlinePutDir", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool XlinePutDir(int hXline, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcRectGetPolyline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RectGetPolyline(int hRect, out double pX, out double pY, out double pBulge);

  [DllImport("Litecad64.dll", EntryPoint="lcImgRefGetPixel", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImgRefGetPixel(int hImgRef, int iX, int iY, out double pX, out double pY, out int pGreyVal);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanAddVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanAddVer(int hRPlan, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanSetCurve", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool RPlanSetCurve(int hVer, double Radius, double LenClot1, double LenClot2);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanSetPos", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool RPlanSetPos(int hVer, double X, double Y);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanDeleteVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool RPlanDeleteVer(int hRPlan, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetFirstVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanGetFirstVer(int hRPlan);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetNextVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanGetNextVer(int hRPlan, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetLastVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanGetLastVer(int hRPlan);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetPrevVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanGetPrevVer(int hRPlan, int hVer);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetVer", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int RPlanGetVer(int hRPlan, int Index);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool RPlanGetPoint(int hRPlan, double Dist, out double pX, out double pY, out double pAngle, out int pSide);

  [DllImport("Litecad64.dll", EntryPoint="lcRPlanGetDist", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool RPlanGetDist(int hRPlan, double X, double Y, out double pX2, out double pY2, out double pDist, out double pOffset);

  [DllImport("Litecad64.dll", EntryPoint="lcColorIsRGB", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ColorIsRGB(string szColor);

  [DllImport("Litecad64.dll", EntryPoint="lcColorGetRed", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ColorGetRed(string szColor);

  [DllImport("Litecad64.dll", EntryPoint="lcColorGetGreen", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ColorGetGreen(string szColor);

  [DllImport("Litecad64.dll", EntryPoint="lcColorGetBlue", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ColorGetBlue(string szColor);

  [DllImport("Litecad64.dll", EntryPoint="lcColorGetIndex", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ColorGetIndex(string szColor);

  [DllImport("Litecad64.dll", EntryPoint="lcColorToVal", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ColorToVal(string szColor, out int pbRGB, out int pIndex, out int pR, out int pG, out int pB);

  [DllImport("Litecad64.dll", EntryPoint="lcColorSetPalette", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ColorSetPalette(int Index, int R, int G, int B);

  [DllImport("Litecad64.dll", EntryPoint="lcColorGetPalette", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ColorGetPalette(int Index, out int pR, out int pG, out int pB);

  [DllImport("Litecad64.dll", EntryPoint="lcColorSetTopo", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ColorSetTopo(int Index, int R, int G, int B);

  [DllImport("Litecad64.dll", EntryPoint="lcImageLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageLoad(int hImage, string szFilename, int hWnd);

  [DllImport("Litecad64.dll", EntryPoint="lcImageLoadDIB", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageLoadDIB(int hImage, int hDib2);

  [DllImport("Litecad64.dll", EntryPoint="lcImageCopyQuad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageCopyQuad(int hImage, int hImageSrc, int W, int H, double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3);

  [DllImport("Litecad64.dll", EntryPoint="lcImageSetPixelRGB", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageSetPixelRGB(int hImage, int X, int Y, int Red, int Green, int Blue);

  [DllImport("Litecad64.dll", EntryPoint="lcImageSetPixelI", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageSetPixelI(int hImage, int X, int Y, int iColor);

  [DllImport("Litecad64.dll", EntryPoint="lcImageGetPixelRGB", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageGetPixelRGB(int hImage, int X, int Y, out int pRed, out int pGreen, out int pBlue);

  [DllImport("Litecad64.dll", EntryPoint="lcImageGetPixelI", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageGetPixelI(int hImage, int X, int Y, out int piColor);

  [DllImport("Litecad64.dll", EntryPoint="lcImageSetPalColor", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageSetPalColor(int hImage, int iColor, int Red, int Green, int Blue);

  [DllImport("Litecad64.dll", EntryPoint="lcImageGetPalColor", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ImageGetPalColor(int hImage, int iColor, out int pRed, out int pGreen, out int pBlue);

  [DllImport("Litecad64.dll", EntryPoint="lcFilletSetLines", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool FilletSetLines(double L1x0, double L1y0, double L1x1, double L1y1, double L2x0, double L2y0, double L2x1, double L2y1);

  [DllImport("Litecad64.dll", EntryPoint="lcFillet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Fillet(double Rad, double Bis, double Tang);

  [DllImport("Litecad64.dll", EntryPoint="lcFilletGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool FilletGetPoint(int iPnt, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldSet", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldSet(int hDrw, double Lef, double Bot, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldClear", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldClear(int hDrw);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldDivide", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WFieldDivide(int hDrw, int NumX, int NumY, bool bClearExist);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldAddCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldAddCR(int hDrw, int ID, double Lef, double Bot, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldSetCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldSetCR(int hDrw, int ID, double Lef, double Bot, double Width, double Height);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldDeleteCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldDeleteCR(int hDrw, int ID);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldActiveCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldActiveCR(int hDrw, int ID);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldSave", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldSave(int hDrw, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool WFieldLoad(int hDrw, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldFirstCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WFieldFirstCR(int hDrw);

  [DllImport("Litecad64.dll", EntryPoint="lcWFieldNextCR", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int WFieldNextCR(int hDrw, int hEnt);

  [DllImport("Litecad64.dll", EntryPoint="lcExpEntity", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ExpEntity(int hEnt, int Flags, bool bUnrotate);

  [DllImport("Litecad64.dll", EntryPoint="lcExpGetPline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int ExpGetPline(double Delta);

  [DllImport("Litecad64.dll", EntryPoint="lcExpGetVertex", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool ExpGetVertex(out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lc2_Initialize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_Initialize();

  [DllImport("Litecad64.dll", EntryPoint="lc2_Uninitialize", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_Uninitialize();

  [DllImport("Litecad64.dll", EntryPoint="lc2_Create", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_Create(IntPtr hWndParent, int Flags);

  [DllImport("Litecad64.dll", EntryPoint="lc2_Delete", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_Delete(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_OnClose", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_OnClose(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_Position", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_Position(int hFrame, int Left, int Top, int Width, int Height);

  [DllImport("Litecad64.dll", EntryPoint="lc2_Command", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_Command(int hFrame, int Command, int CmdParam);

  [DllImport("Litecad64.dll", EntryPoint="lc2_GetWnd", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_GetWnd(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_GetDrw", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_GetDrw(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_GetBlock", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_GetBlock(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_FileLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_FileLoad(int hFrame, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lc2_FileSave", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_FileSave(int hFrame, string szFileName, bool bBak);

  [DllImport("Litecad64.dll", EntryPoint="lc2_WFieldSave", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_WFieldSave(int hFrame, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lc2_WFieldLoad", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_WFieldLoad(int hFrame, string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lc2_ExpStart", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_ExpStart(int hFrame, int Mode);

  [DllImport("Litecad64.dll", EntryPoint="lc2_ExpGetPline", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_ExpGetPline(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_ExpGetEntity", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern int lc2_ExpGetEntity(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_ExpGetVertex", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_ExpGetVertex(int hFrame, out double pX, out double pY);

  [DllImport("Litecad64.dll", EntryPoint="lc2_ExpGetPoint", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_ExpGetPoint(int hFrame);

  [DllImport("Litecad64.dll", EntryPoint="lc2_CbCopy", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_CbCopy(int hFrame, double Lef, double Bot, double W, double H);

  [DllImport("Litecad64.dll", EntryPoint="lc2_CbCopy2", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_CbCopy2(int hFrame, int idClipRect, bool bUnrotate);

  [DllImport("Litecad64.dll", EntryPoint="lc2_CbPaste", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool lc2_CbPaste(int hFrame, double Lef, double Bot);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_EnableFileExt", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_EnableFileExt(string szFileExt);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_Load", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_Load(string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_Save", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_Save();

  [DllImport("Litecad64.dll", EntryPoint="lcMru_AddFile", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_AddFile(string szFileName, bool bFileHasView);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_SetImage", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_SetImage(string szFileName, out IntPtr pImgBuf, int ImgSize);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_HasImage", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_HasImage(string szFileName);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_SetViewRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_SetViewRect(string szFileName, double Xmin, double Ymin, double Xmax, double Ymax);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_GetViewRect", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_GetViewRect(string szFileName, out double pXmin, out double pYmin, out double pXmax, out double pYmax);

  [DllImport("Litecad64.dll", EntryPoint="lcMru_Dialog", CharSet = CharSet.Unicode, ExactSpelling = true)]
  public static extern bool Mru_Dialog(IntPtr hWnd, int hIcon, out IntPtr szFileName);

}
