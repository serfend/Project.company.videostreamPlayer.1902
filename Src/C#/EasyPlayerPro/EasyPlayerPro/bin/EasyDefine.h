/* ��׼ͷ�ļ� */
#ifndef __EASYDEFINE_H__
#define __EASYDEFINE_H__

#if defined(WIN32)
#include <windows.h>
#include <mmsystem.h>
#include <tchar.h>
#define  usleep(us)  Sleep((us)/1000)
#else
// todo..
#endif

//ͨ��Դ���� (ָ��Դ����)
typedef enum __EASY_CHANNEL_SOURCE_TYPE_ENUM
{
	EASY_CHANNEL_SOURCE_TYPE_RTSP = 0,		//ԴΪRTSP(����)
	EASY_CHANNEL_SOURCE_TYPE_RTMP,				//ԴΪRTMP(����)
	EASY_CHANNEL_SOURCE_TYPE_HLS,				//ԴΪHLS(����)
	EASY_CHANNEL_SOURCE_TYPE_FILE,				//ԴΪ�����ļ�(����)
	EASY_CHANNEL_SOURCE_TYPE_ENCODE_DATA,		//ԴΪ�ⲿ�ı�������
	EASY_CHANNEL_SOURCE_TYPE_DECODE_DATA,		//ԴΪ�ⲿ�Ľ�������
}EASY_CHANNEL_SOURCE_TYPE_ENUM;

//ˮӡ�ṹ��Ϣ
// //ö�ٱ�ʶ̨��LOGO���ڵ�λ��
typedef enum tagWATER_MARK_POS
{
	POS_LEFT_TOP = 1,
	POS_RIGHT_TOP,
	POS_LEFT_BOTTOM,
	POS_RIGHT_BOTTOM

}WATER_MARK_POS;

typedef enum tagWATERMARK_ENTRY_TYPE
{
	WATERMARK_TYPE_COVER			   = 0,
	WATERMARK_TYPE_OVERLYING		   = 1,
	WATERMARK_TYPE_OVERLYING_COVER	   = 2,
	WATERMARK_TYPE_ROLL_TO_LEFT		   = 3,
	WATERMARK_TYPE_JUMP_UP_DOWN		   = 4,
	WATERMARK_TYPE_ROLL_AND_JUMP	   = 5,
	WATERMARK_TYPE_TROTTING_HORSE_LAMP = 6

}WATERMARK_ENTRY_TYPE;

typedef enum __AUTH_ERR_CODE_ENUM
{
	AUTH_INVALID_KEY = -1,			/* ��ЧKey */
	AUTH_TIME_ERR = -2,			/* ʱ����� */
	AUTH_PROCESS_NAME_LEN_ERR = -3,			/* �������Ƴ��Ȳ�ƥ�� */
	AUTH_PROCESS_NAME_ERR = -4,			/* �������Ʋ�ƥ�� */
	AUTH_VALIDITY_PERIOD_ERR = -5,			/* ��Ч��У�鲻һ�� */
	AUTH_PLATFORM_ERR = -6,			/* ƽ̨��ƥ�� */
	AUTH_COMPANY_ID_LEN_ERR = -7,			/* ��Ȩʹ���̲�ƥ�� */
	AUTH_SUCCESS = 0,			/* ����ɹ� */

}AUTH_ERR_CODE_ENUM;

typedef enum tagSPEED_RATE
{
	SPEED_SLOW_X16 = -4,
	SPEED_SLOW_X8 = -3,
	SPEED_SLOW_X4 = -2,
	SPEED_SLOW_X2 = -1,
	SPEED_NORMAL = 0,
	SPEED_FAST_X2 = 1,
	SPEED_FAST_X4 = 2,
	SPEED_FAST_X8 = 3,
	SPEED_FAST_X16 = 4,
	SPEED_FAST_X64 = 5,
}SPEED_RATE;

// //��Ļ��Ϣ
typedef struct tagVideoTittleInfo
{
	int nState;//��Ļ״̬��	nState==1���У�nState==0��ͣ��nState==-1����
	//�����������Ϣ
	int nTittleWidth;
	int nTittleHeight;
	int nFontWeight;//Ȩ�� FW_NORMAL FW_BOLD������
	char strFontType[64];//���� "������κ");//"��������");"����"
	char strTittleContent[512];//��Ļ����
	// ��Ļ��ɫ
	int nColorR;
	int nColorG;
	int nColorB;
	POINT ptStartPosition;//��Ļ���ƿ�ʼ��
	int   nMoveType;//0--�̶�λ�ã�1--�������ң�2--��������
	BOOL bResetTittleInfo;
}VideoTittleInfo;

typedef struct tagWaterMarkInfo
{
	BOOL bIsUseWaterMark;//�Ƿ�ʹ��ˮӡ
	WATER_MARK_POS eWaterMarkPos;//̨��λ�ã�1==leftttop 2==righttop 3==leftbottom 4==rightbottom
	int nLeftTopX;//ˮӡ���Ͻ�λ��x
	int nLeftTopY;//ˮӡ���Ͻ�λ��y
	int nWidth;//��
	int nHeight;//��
	char strWMFilePath[512];//ˮӡͼƬ·��
	WATERMARK_ENTRY_TYPE eWatermarkStyle;//ˮӡ�ķ��
	BOOL bResetWaterMark;

}WaterMarkInfo;

typedef struct tagMediaInfo
{
	//for stream
	int nBitsRate;
	//for Video
	int nVCodec;
	char sVCodec[32];
	char sVCodecDetails[64];
	int nWidth;
	int nHeight;
	int nFrameRate;
	int video_bit_rate;
	int video_total_bit_rate;
	//for Audio
	int nACodec;
	char sACodec[32];
	char sACodecDetails[64];
	int nSampleRate;
	int nChannels;
	int nBitsPerSample;
	int audio_bit_rate;
	//ͳ��
	int nStatisticsFPS;
	float fStatisticsBitsrate;

}MediaInfo;

//ý����Ϣ
typedef struct __EASY_MEDIA_INFO_T
{
	unsigned int videoCodec;			//��Ƶ��������
	unsigned int videoFps;				//��Ƶ֡��
	int			 videoWidth;
	int			 videoHeight;
	int		 videoBitrate;

	unsigned int audioCodec;			//��Ƶ��������
	unsigned int audioSampleRate;		//��Ƶ������
	unsigned int audioChannel;			//��Ƶͨ����
	unsigned int audioBitsPerSample;	//��Ƶ��������

	unsigned int metadataCodec;			//Metadata����

	unsigned int vpsLength;				//��Ƶvps֡����
	unsigned int spsLength;				//��Ƶsps֡����
	unsigned int ppsLength;				//��Ƶpps֡����
	unsigned int seiLength;				//��Ƶsei֡����
	unsigned char	 vps[255];			//��Ƶvps֡����
	unsigned char	 sps[255];			//��Ƶsps֡����
	unsigned char	 pps[128];			//��Ƶsps֡����
	unsigned char	 sei[128];			//��Ƶsei֡����
}EASY_MEDIA_INFO_T;



#endif


