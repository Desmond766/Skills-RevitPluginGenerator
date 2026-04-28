---
kind: method
id: M:Autodesk.Revit.DB.Architecture.BalusterInfo.GetReferenceNameForHost
source: html/9519e69c-82c0-6444-6568-0d29cf9db0b5.htm
---
# Autodesk.Revit.DB.Architecture.BalusterInfo.GetReferenceNameForHost Method

Gets the name string to be used as a reference to Host in the current language.

## Syntax (C#)
```csharp
public static string GetReferenceNameForHost()
```

## Returns
The name string to be used as a reference to Host.

## Remarks
This name can be used in the setter for BaseReferenceName 
 or TopReferenceName .
 The name can also be compared with the value coming from the getter.

