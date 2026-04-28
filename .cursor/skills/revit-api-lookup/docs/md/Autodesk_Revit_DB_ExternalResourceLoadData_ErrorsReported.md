---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceLoadData.ErrorsReported
source: html/c049b9ef-40e4-5428-510c-056d57c4d815.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadData.ErrorsReported Property

Indicates whether the IExternalResourceUIServer has reported errors
 for this ExternalResourceLoadData. This value can be set by the
 IExternalResourceUIServer in HandleLoadResourceResults().

## Syntax (C#)
```csharp
public bool ErrorsReported { get; set; }
```

## Remarks
For Revit links specifically, Revit will check this value to see
 if it should report errors about a given link in the Unresolved
 References dialog. An IExternalResourceUIServer can set this value
 to true to avoid redundant messages. Note that it is possible for Revit to encounter errors internally
 even if the server successfully provides a reference. In general, this
 value should only be set to true if the server has reported an
 error condition.

