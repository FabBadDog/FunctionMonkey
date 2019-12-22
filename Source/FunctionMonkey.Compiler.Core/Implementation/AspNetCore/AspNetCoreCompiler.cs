using System.Collections.Generic;
using FunctionMonkey.Abstractions;

namespace FunctionMonkey.Compiler.Core.Implementation.AspNetCore
{
    internal class AspNetCoreCompiler : ITargetCompiler
    {
        private readonly ICompilerLog _compilerLog;
        private readonly IAssemblyCompiler _assemblyCompiler;

        public AspNetCoreCompiler(ICompilerLog compilerLog)
        {
            _compilerLog = compilerLog;
            _assemblyCompiler = new AspNetCoreAssemblyCompiler(compilerLog, new TemplateProvider(CompileTargetEnum.AspNetCore));
        }
        
        public bool CompileAssets(IFunctionCompilerMetadata functionCompilerMetadata, string newAssemblyNamespace,
            IFunctionAppConfiguration configuration, IReadOnlyCollection<string> externalAssemblies, string outputBinaryFolder)
        {
            _compilerLog.Warning("ASP.Net Core output is currently experimental");
            
            FunctionMonkey.Compiler.Core.HandlebarsHelpers.AspNetCore.HandlebarsHelperRegistration.RegisterHelpers();
            
            return _assemblyCompiler.Compile(functionCompilerMetadata.FunctionDefinitions,
                configuration?.GetType() ?? functionCompilerMetadata.BacklinkReferenceType,
                configuration != null ? null : functionCompilerMetadata.BacklinkPropertyInfo,
                newAssemblyNamespace,
                externalAssemblies,
                outputBinaryFolder,
                $"{newAssemblyNamespace}.dll",
                functionCompilerMetadata.CompileTarget,
                functionCompilerMetadata.OutputAuthoredSourceFolder);
        }
    }
}