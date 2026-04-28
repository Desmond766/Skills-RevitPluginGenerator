---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkOptions.#ctor(System.Boolean)
source: html/ec59e0c0-56ba-5bcd-3aa3-22150b152457.htm
---
# Autodesk.Revit.DB.RevitLinkOptions.#ctor Method

Creates a RevitLinkOptions object, specifying relative or absolute path type.
 If the link is workshared, all worksets will be opened.

## Syntax (C#)
```csharp
public RevitLinkOptions(
	bool relative
)
```

## Parameters
- **relative** (`System.Boolean`) - True if the link should use a relative path. False if it should use an
 absolute path.

