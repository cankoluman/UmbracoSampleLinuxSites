MONO_PREFIX=/usr

#unset parallel mono environment
export MONO_GAC_PREFIX=$MONO_PREFIX
export DYLD_LIBRARY_FALLBACK_PATH=`echo ${DYLD_LIBRARY_FALLBACK_PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
export LD_LIBRARY_PATH=`echo ${LD_LIBRARY_PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
export C_INCLUDE_PATH=`echo ${C_INCLUDE_PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
export ACLOCAL_PATH=`echo ${ACLOCAL_PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
export PKG_CONFIG_PATH=`echo ${PKG_CONFIG_PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
export PATH=`echo ${PATH} | awk -v RS=: -v ORS=: '/opt/ {next} {print}'  | sed 's/:*$//'`
