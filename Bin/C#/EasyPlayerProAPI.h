
/*
	Copyright (c) 2013-2017 EasyDarwin.ORG.  All rights reserved.
	Github: https://github.com/EasyDarwin
	WEChat: EasyDarwin
	Website: http://www.easydarwin.org
*/
#ifndef __EasyPlayerProAPI_H__
#define __EasyPlayerProAPI_H__


//++ typedefine start
#ifndef EASY_HANDLE
#define EASY_HANDLE void*
#endif//EASY_HANDLE

#ifndef Easy_PlayerPro_Handle
#define Easy_PlayerPro_Handle void*
#endif//Easy_PlayerPro_Handle

#ifndef EASY_VERYLONG
#define EASY_VERYLONG __int64
#endif//EASY_VERYLONG
//-- typedefine end


// adev render type
typedef enum tagEASY_AUDIO_RENDER_TYPE
{
	//waveout
	EASY_AUDIO_RENDER_TYPE_WAVEOUT = 0,
}EASY_AUDIO_RENDER_TYPE;

// vdev render type
typedef enum tagEASY_VIDEO_RENDER_TYPE
{
	EASY_VIDEO_RENDER_TYPE_GDI = 0,
	EASY_VIDEO_RENDER_TYPE_D3D,
//	EASY_VIDEO_RENDER_TYPE_OPENGL,
	EASY_VIDEO_RENDER_TYPE_MAX_NUM,
}EASY_VIDEO_RENDER_TYPE;

// render mode
typedef enum tagEASY_VIDEO_SCALE_MODE
{
	//���������ʾ����
	EASY_VIDEO_MODE_STRETCHED,
	//���������ŵ���ʾ����
	EASY_VIDEO_MODE_LETTERBOX,
	EASY_VIDEO_MODE_MAX_NUM,
}EASY_VIDEO_SCALE_MODE;

// link mode
typedef enum tagEASY_STREAM_LINK_MODE
{
	//���������ŵ���ʾ����
	EASY_STREAM_LINK_UDP = 0,
	//���������ʾ����
	EASY_STREAM_LINK_TCP,
	EASY_STREAM_LINK_MODE_NUM,
}EASY_STREAM_LINK_MODE;

// audio visual effect
typedef enum tagEASY_AUDIO_VISUAL_EFFECT_MODE
{
	EASY_AUDIO_VISUAL_EFFECT_DISABLE,
	EASY_AUDIO_VISUAL_EFFECT_WAVEFORM,
	EASY_AUDIO_VISUAL_EFFECT_SPECTRUM,
	EASY_AUDIO_VISUAL_EFFECT_MAX_NUM,
}EASY_AUDIO_VISUAL_EFFECT_MODE;

// hwaccel type ��Ƶ��ȾӲ����������
typedef enum tagEASY_VIDEO_HARDWARE_ACCEL_TYPE
{
	EASY_VIDEO_HWACCEL_TYPE_NONE,
	EASY_VIDEO_HWACCEL_TYPE_DXVA2,
	EASY_VIDEO_HWACCEL_TYPE_MAX_NUM,
}EASY_VIDEO_HARDWARE_ACCEL_TYPE;

// param
typedef enum tagEASY_PARAM_ID
{
	//++ public
	// duration & position
	EASY_PARAM_MEDIA_DURATION = 0x1000,
	EASY_PARAM_MEDIA_POSITION,

	// media detail info
	EASY_PARAM_MEDIA_INFO,
	EASY_PARAM_VIDEO_WIDTH,
	EASY_PARAM_VIDEO_HEIGHT,

	// video display mode
	EASY_PARAM_VIDEO_MODE,

	// audio volume control
	EASY_PARAM_AUDIO_VOLUME,

	// playback speed control
	EASY_PARAM_PLAY_SPEED,
	EASY_PARAM_PLAY_SPEED_TYPE,

	// video decode thread count
	EASY_PARAM_DECODE_THREAD_COUNT,

	// visual effect mode
	EASY_PARAM_VISUAL_EFFECT,

	// audio/video sync diff
	EASY_PARAM_AVSYNC_TIME_DIFF,

	// player event callback
	EASY_PARAM_PLAYER_CALLBACK,

	// audio/video stream
	EASY_PARAM_AUDIO_STREAM_TOTAL,
	EASY_PARAM_VIDEO_STREAM_TOTAL,
	EASY_PARAM_SUBTITLE_STREAM_TOTAL,
	EASY_PARAM_AUDIO_STREAM_CUR,
	EASY_PARAM_VIDEO_STREAM_CUR,
	EASY_PARAM_SUBTITLE_STREAM_CUR,

	//++ for media record 
	EASY_PARAM_RECORD_TIME,
	EASY_PARAM_RECORD_PIECE_ID,
	//-- for media record
	//-- public

	//++ for audio render type
	EASY_PARAM_ADEV_RENDER_TYPE = 0x2000,
	EASY_PARAM_ADEV_GET_CONTEXT,
	EASY_PARAM_ADEV_MUTE,
	//-- for audio render type

	//++ for vdev
	EASY_PARAM_VDEV_RENDER_TYPE = 0x3000,
	EASY_PARAM_VDEV_FRAME_RATE,
	EASY_PARAM_VDEV_GET_CONTEXT,
	EASY_PARAM_VDEV_POST_SURFACE,
	EASY_PARAM_VDEV_GET_D3DDEV,
	EASY_PARAM_VDEV_D3D_ROTATE,
	//-- for vdev

	//++ for render
	EASY_PARAM_RENDER_UPDATE    = 0x4000,
	EASY_PARAM_RENDER_START_PTS,
	//-- for render

}EASY_PARAM_ID;

#ifdef __cplusplus
extern "C"
{
#endif

	// EasyPlayerPro�ӿں�������
	int EasyPlayerPro_Authorize(char *license);

	Easy_PlayerPro_Handle EasyPlayerPro_Create();
	void EasyPlayerPro_Release(Easy_PlayerPro_Handle player);

	// 	EasyPlayerPro_Open     ��һ��ý��������ý���ļ����в��ţ�ͬʱ����һ�� player ����ָ��
	// 		fileUrl				- �ļ�·����������������ý��� URL��
	// 		hWnd				- Win32 �Ĵ��ھ��/����ƽ̨��Ⱦ��ʾ�豸���
	//		render_mode			- ��Ƶ��Ⱦģʽ�����EASY_VIDEO_RENDER_TYPE
	//		video_mode			- ��Ƶ��ʾģʽ�����EASY_VIDEO_SCALE_MODE
	//		link_mode			- ������ģʽ��Ŀǰֻ��RTSP����Ч������rtp over tcp/udp,	���EASY_STREAM_LINK_MODE
	//		speed				- �����ٶȣ�0-100���ţ�100���Ͽ��
	//		valume				- ����������-255 - +255
	// 		����ֵ				- Easy_PlayerPro_Handle ָ�����ͣ�ָ�� easyplayerpro ������
	Easy_PlayerPro_Handle EasyPlayerPro_Open(Easy_PlayerPro_Handle player,
		char *fileUrl, EASY_HANDLE hWnd,
		EASY_VIDEO_RENDER_TYPE render_type,
		EASY_VIDEO_SCALE_MODE  video_mode,
		EASY_STREAM_LINK_MODE  link_mode,
		int					   speed,
		int					   valume);

	// 	EasyPlayerPro_Close    �رղ���
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	void  EasyPlayerPro_Close(Easy_PlayerPro_Handle player);

	// 	EasyPlayerPro_Play     ��ʼ���ţ�ע�⣺ý���������ļ��򿪺���Ҫ���ô˺�������ʼ���ţ�
	// 							�˺�������ͣ���������ŵ�ʱ����ã��������������߼�
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	void  EasyPlayerPro_Play(Easy_PlayerPro_Handle player);

	// 	EasyPlayerPro_StepPlay �������ţ�һ�β���һ֡������EasyPlayerPro_Play������������
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	//		type				- �����������ͣ�1-��ǰ 2-���
	void  EasyPlayerPro_StepPlay(Easy_PlayerPro_Handle player, int type);


	// 	EasyPlayerPro_Pause		��ͣ���ţ�����EasyPlayerPro_Play������������
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	void  EasyPlayerPro_Pause(Easy_PlayerPro_Handle player);


	// 	EasyPlayerPro_Seek     ��ת��ָ��λ��
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		seek				- ָ��λ�ã��Ժ���Ϊ��λ
	void  EasyPlayerPro_Seek(Easy_PlayerPro_Handle player, EASY_VERYLONG seek);


	// 	EasyPlayerPro_Resize   ������ʾ������������ʾ������Ƶ��ʾ�����Ӿ�Ч����ʾ��
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		type				- ָ����������  0 - video rect, 1 - audio visual effect rect
	// 		x,y,width,height	- ָ����ʾ��������
	void  EasyPlayerPro_Resize (Easy_PlayerPro_Handle player, int type, int x, int y, int width, int height); 


	// 	EasyPlayerPro_Snapshot ��Ƶ���Ž�ͼ
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		filePath			- ͼƬ���·������.xxx������xxx Ŀǰֻ֧�� jpeg ��ʽ��
	// 		width, height       - ָ��ͼƬ��ߣ���� <= 0 ��Ĭ��ʹ����Ƶ���
	// 		waittime			- �Ƿ�ȴ���ͼ��� 0 - ���ȴ���>0 �ȴ���ʱ ms Ϊ��λ
	int   EasyPlayerPro_Snapshot(Easy_PlayerPro_Handle player, char *filePath, int width, int height, int waitTime);


	// 	EasyPlayerPro_Record   ��Ƶ����¼��
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		filePath			- ͼƬ���·������.xxx������xxx Ŀǰֻ֧�� mp4 ��ʽ��
	// 		duration			- ָ��ͼƬ��ߣ���� <= 0 ��Ĭ��ʹ����Ƶ���
	int   EasyPlayerPro_Record (Easy_PlayerPro_Handle player, char *filePath, int duration );


	// 	EasyPlayerPro_Record   ��Ƶ����ֹͣ¼��
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	int   EasyPlayerPro_Stoprecord(Easy_PlayerPro_Handle player);

	// 	EasyPlayerPro_SetLogo  ����̨��/LOGO
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		bIsUse				- �Ƿ�ʹ��ˮӡ 1=���� 0=������
	// 		ePos				- ̨��λ�ã�1==leftttop 2==righttop 3==leftbottom 4==rightbottom
	// 		eStyle				-  ˮӡ�ķ�񣬼�WATERMARK_ENTRY_TYPE����
	// 		x					- ˮӡ���Ͻ�λ��x����
	// 		y					- ˮӡ���Ͻ�λ��y����
	// 		width				- ��
	// 		height				- ��
	// 		logopath			- ˮӡͼƬ·��
	int   EasyPlayerPro_SetLogo (void* hplayer, int bIsUse, int ePos, int eStyle, 
		int x, int y, int width, int height, char* logopath);

	// 	EasyPlayerPro_SetOSD  ���õ�����Ļ
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		bIsUse				- �Ƿ�ʹ��ˮӡ 1=���� 0=������ -1=ɾ��
	// 		nMoveType			- �ƶ����ͣ�0--�̶�λ�ã�1--�������ң�2--��������
	//		R,G,B				- ������ɫ��Ӧ��������������0-255
	// 		x					- ��Ļ��ʾ���Ͻ�λ��x����
	// 		y					- ��Ļ��ʾ���Ͻ�λ��y����
	// 		weight				- ����Ȩ�أ�����������
											// /* Font Weights */
											// #define FW_DONTCARE         0
											// #define FW_THIN             100
											// #define FW_EXTRALIGHT       200
											// #define FW_LIGHT            300
											// #define FW_NORMAL           400
											// #define FW_MEDIUM           500
											// #define FW_SEMIBOLD         600
											// #define FW_BOLD             700
											// #define FW_EXTRABOLD        800
											// #define FW_HEAVY            900
											// #define FW_ULTRALIGHT       FW_EXTRALIGHT
											// #define FW_REGULAR          FW_NORMAL
											// #define FW_DEMIBOLD         FW_SEMIBOLD
											// #define FW_ULTRABOLD        FW_EXTRABOLD
											// #define FW_BLACK            FW_HEA
	// 		width				- ��
	// 		height				- ��
	// 		fontname			- �������ƣ��硰���塱�����塱�����顱�������п���......
	//		tittleContent		- OSD��ʾ����
	int   EasyPlayerPro_SetOSD (void *hplayer, int bIsUse, int nMoveType, int R, int G, int B,
		int weight, int x, int y, int width, int height, char* fontname, char* tittleContent);

	// 	EasyPlayerPro_Setparam ���ò���
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		param_id			- ����ID����EASY_PARAM_ID����
	// 		param				- ����ָ��
	void  EasyPlayerPro_Setparam(Easy_PlayerPro_Handle player, EASY_PARAM_ID param_id, EASY_HANDLE param);

	// 	EasyPlayerPro_Setparam ��ȡ����
	// 		player				- ָ�� EasyPlayerPro_Open ���ص� player ����
	// 		param_id			- ����ID����EASY_PARAM_ID����
	// 		param				- ����ָ��
	void  EasyPlayerPro_Getparam(Easy_PlayerPro_Handle player, EASY_PARAM_ID param_id, EASY_HANDLE param);


#ifdef __cplusplus
}
#endif

#endif


// ����˵��
/*
EASY_PARAM_MEDIA_DURATION �� EASY_PARAM_MEDIA_POSITION
���ڻ�ȡ��ý���ļ����ܳ��Ⱥ͵�ǰ����λ�ã�����Ϊ��λ��
LONGLONG total = 1, pos = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_MEDIA_DURATION, &total);
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_MEDIA_POSITION, &pos  );

EASY_PARAM_VIDEO_WIDTH �� EASY_PARAM_VIDEO_HEIGHT
���ڻ�ȡ��ý���ļ�����Ƶ��Ⱥ͸߶ȣ�����Ϊ��λ��
int vw = 0, vh = 0;
EasyPlayerPro_Getparam(g_hplayer, PARAM_VIDEO_WIDTH , &vw);
EasyPlayerPro_Getparam(g_hplayer, PARAM_VIDEO_HEIGHT, &vh);

EASY_PARAM_VIDEO_MODE
���ڻ�ȡ��������Ƶ��ʾ��ʽ�������ַ�ʽ��ѡ��
    1. EASY_VIDEO_MODE_LETTERBOX - ���������ŵ���ʾ����
    2. EASY_VIDEO_MODE_STRETCHED - ���쵽��ʾ����
��ע����Ƶ��ʾ������ EasyPlayerPro_Resize �����趨��
int mode = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_VIDEO_MODE, &mode);
mode = VIDEO_MODE_STRETCHED;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_VIDEO_MODE, &mode);

EASY_PARAM_AUDIO_VOLUME
�������ò�����������ͬ��ϵͳ������player �ڲ�����һ�� -30dB �� +12dB ������������Ƶ�Ԫ
������Χ��[-182, 73]��-182 ��Ӧ -30dB��73 ��Ӧ +12dB
����ֵ  ��0 ��Ӧ 0dB ���棬-255 ��Ӧ������+255 ��Ӧ�������
int volume = -0;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_AUDIO_VOLUME, &volume);

EASY_PARAM_PLAY_SPEED
�������ò����ٶȣ�player ֧�ֱ��ٲ���
int speed = 150;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_PLAY_SPEED, &speed);
���� speed Ϊ�ٷֱ��ٶȣ�150 ��ʾ�� 150% ���в���
�ٶ�û�����޺����ޣ�����Ϊ 0 û�����壬�ڲ��ᴦ��Ϊ 1%
�����ٶȵ�ʵ�����ޣ��ɴ������Ĵ��������������������������������Ż���ֿ�������

EASY_PARAM_DECODE_THREAD_COUNT
����������Ƶ�����߳�������ե�� cpu ��Դ
int count = 6;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_DECODE_THREAD_COUNT, &count);
����Ϊ 0 Ϊ���Զ���ȡ�豸�� CPU ���ĸ�������������ý����̸߳���
����Ϊ 1 Ϊ���߽��룬����Ϊ >= 2 ��ֵΪ���߳̽���
���������ú�һ�����������϶��߳̽��룬��Ҫ����Ӧ�� decoder �Ƿ�֧�ֶ��߳̽���
һ�����������Ϊ 4 - 10 ���ҵ�ֵ���ܳ��եȡ cpu ��Դ����֤���ŵ���������

EASY_PARAM_VISUAL_EFFECT
����ָ���Ӿ�Ч�������ͣ�player ֧���Ӿ�Ч������Ҫ�Ƕ���Ƶ�����Ӿ�Ч���ĳ���
int mode = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_VISUAL_EFFECT, &mode);
mode = EASY_AUDIO_VISUAL_EFFECT_WAVEFORM;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_VISUAL_EFFECT, &mode);
Ŀǰ�ܹ��������Ӿ�Ч����
    1. VISUAL_EFFECT_DISABLE  - �ر�
    2. VISUAL_EFFECT_WAVEFORM - ����
    3. VISUAL_EFFECT_SPECTRUM - Ƶ��
��ע���Ӿ�Ч�������� EasyPlayerPro_Resize �����趨��

EASY_PARAM_AVSYNC_TIME_DIFF
�������� audio �� video ��ʱ��ͬ����ֵ������Ϊ��λ��
int diff = 100;
EasyPlayerPro_Setparam(g_hplayer, EASY_PARAM_AVSYNC_TIME_DIFF, &diff);
Eg: ����Ϊ 100 ����Ƶ������Ƶ�� 100ms������Ϊ -100 ���� 100ms

EASY_PARAM_PLAYER_CALLBACK
�������ò������¼��ص��������ص�������ԭ�Ͷ������£�
typedef void (*EASY_PLAYERPRO_CALLBACK)(__int32 msg, __int64 param);
�ص�ʱ�Ĳ����������£�
    msg   - PLAY_PROGRESS ���Ž����У�PLAY_COMPLETED �������
    param - ��ǰ���Ž��ȣ��Ժ���Ϊ��λ

EASY_PARAM_VDEV_RENDER_TYPE
����������Ƶ��Ⱦ��ʽ��Ŀǰ�� EASY_VIDEO_RENDER_TYPE_GDI �� EASY_VIDEO_RENDER_TYPE_D3D ���ֿ�ѡ
int mode = 0;
EasyPlayerPro_Getparam(g_hplayer, PARAM_VDEV_RENDER_TYPE, &mode);
mode = EASY_VIDEO_RENDER_TYPE_D3D;
EasyPlayerPro_Setparam(g_hplayer, PARAM_VDEV_RENDER_TYPE, &mode);

EASY_PARAM_AUDIO_STREAM_TOTAL
EASY_PARAM_VIDEO_STREAM_TOTAL
EASY_PARAM_SUBTITLE_STREAM_TOTAL
����������ֻ����(Get)���ֱ����ڻ�ȡ audio, video, subtitle ��������
int streamCount = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_AUDIO_STREAM_TOTAL, &streamCount);

EASY_PARAM_AUDIO_STREAM_CUR
EASY_PARAM_VIDEO_STREAM_CUR
EASY_PARAM_SUBTITLE_STREAM_CUR
���������������ֱ����ڻ�ȡ��Get�������ã�Set����ǰ���ŵ� audio, video, subtitle �����

EASY_PARAM_RECORD_TIME
EASY_PARAM_RECORD_PIECE_ID
��������������ֻ����(Get)���ֱ����ڻ�ȡ¼���ʱ��͵�ǰ��Ƭ��ID
float recordTime = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_RECORD_TIME, &recordTime);
int recordPieceId = 0;
EasyPlayerPro_Getparam(g_hplayer, EASY_PARAM_RECORD_PIECE_ID, &recordPieceId);


���еĲ��������ǿ��� get �ģ������������еĲ��������� set����Ϊ��Щ������ֻ���ġ�

*/