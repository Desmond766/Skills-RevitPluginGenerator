---
kind: method
id: M:Autodesk.Revit.DB.ExportPatternKey.#ctor(Autodesk.Revit.DB.FillPatternTarget,System.String)
source: html/8ccc9a58-cc2b-7e70-f937-9220d49e8052.htm
---
# Autodesk.Revit.DB.ExportPatternKey.#ctor Method

Constructs a new ExportPatternKey using the original fill pattern type and name as input.

## Syntax (C#)
```csharp
public ExportPatternKey(
	FillPatternTarget originalFillPatternType,
	string originalFillPatternName
)
```

## Parameters
- **originalFillPatternType** (`Autodesk.Revit.DB.FillPatternTarget`) - The original FillPattern type.
- **originalFillPatternName** (`System.String`) - The original FillPattern name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

