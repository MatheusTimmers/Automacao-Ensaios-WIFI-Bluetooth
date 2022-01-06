

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.00.0603 */
/* at Wed Apr 28 16:39:08 2021
 */
/* Compiler settings for IviSessionFactory.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.00.0603 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __IviSessionFactory_h__
#define __IviSessionFactory_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IIviSessionFactory_FWD_DEFINED__
#define __IIviSessionFactory_FWD_DEFINED__
typedef interface IIviSessionFactory IIviSessionFactory;

#endif 	/* __IIviSessionFactory_FWD_DEFINED__ */


#ifndef __IviSessionFactory_FWD_DEFINED__
#define __IviSessionFactory_FWD_DEFINED__

#ifdef __cplusplus
typedef class IviSessionFactory IviSessionFactory;
#else
typedef struct IviSessionFactory IviSessionFactory;
#endif /* __cplusplus */

#endif 	/* __IviSessionFactory_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IIviSessionFactory_INTERFACE_DEFINED__
#define __IIviSessionFactory_INTERFACE_DEFINED__

/* interface IIviSessionFactory */
/* [oleautomation][unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IIviSessionFactory;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DE217CF0-2F0C-4EB5-B435-E69400C467EC")
    IIviSessionFactory : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CreateDriver( 
            /* [in] */ BSTR LogicalName,
            /* [retval][out] */ IUnknown **Driver) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CreateSession( 
            /* [in] */ BSTR LogicalName,
            /* [retval][out] */ IUnknown **Session) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IIviSessionFactoryVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IIviSessionFactory * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IIviSessionFactory * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IIviSessionFactory * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *CreateDriver )( 
            IIviSessionFactory * This,
            /* [in] */ BSTR LogicalName,
            /* [retval][out] */ IUnknown **Driver);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *CreateSession )( 
            IIviSessionFactory * This,
            /* [in] */ BSTR LogicalName,
            /* [retval][out] */ IUnknown **Session);
        
        END_INTERFACE
    } IIviSessionFactoryVtbl;

    interface IIviSessionFactory
    {
        CONST_VTBL struct IIviSessionFactoryVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IIviSessionFactory_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IIviSessionFactory_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IIviSessionFactory_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IIviSessionFactory_CreateDriver(This,LogicalName,Driver)	\
    ( (This)->lpVtbl -> CreateDriver(This,LogicalName,Driver) ) 

#define IIviSessionFactory_CreateSession(This,LogicalName,Session)	\
    ( (This)->lpVtbl -> CreateSession(This,LogicalName,Session) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IIviSessionFactory_INTERFACE_DEFINED__ */



#ifndef __IVISESSIONFACTORYLib_LIBRARY_DEFINED__
#define __IVISESSIONFACTORYLib_LIBRARY_DEFINED__

/* library IVISESSIONFACTORYLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_IVISESSIONFACTORYLib;

EXTERN_C const CLSID CLSID_IviSessionFactory;

#ifdef __cplusplus

class DECLSPEC_UUID("1EF38758-06AA-4CAD-9982-2CEA978C5855")
IviSessionFactory;
#endif
#endif /* __IVISESSIONFACTORYLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


