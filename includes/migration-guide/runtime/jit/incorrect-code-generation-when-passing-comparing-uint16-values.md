### Incorrect code generation when passing and comparing UInt16 values

#### Details

Because of changes introduced in the .NET Framework 4.7, in some cases the code generated by the JIT compiler in applications running on the .NET Framework 4.7 incorrectly compares two `T:System.UInt16` values. For more information, see [Issue #11508: Silent bad codegen when passing and comparing ushort args](https://github.com/dotnet/coreclr/issues/11508) on GitHub.com.

#### Suggestion

If you encounter issues in the comparison of 16-bit unsigned values in the .NET Framework 4.7, upgrade to the .NET Framework 4.7.1.

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.7|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
