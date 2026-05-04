---
kind: type
id: T:Autodesk.Revit.DB.FormatOptions
source: html/70f78207-1109-3906-8e67-cd27df1f0ae8.htm
---
# Autodesk.Revit.DB.FormatOptions

Options for formatting numbers with units.

## Syntax (C#)
```csharp
public class FormatOptions : IDisposable
```

## Remarks
The FormatOptions class contains settings that control how to
 format numbers with units as strings. It contains those settings that
 are typically chosen by an end user in the Format dialog and stored in
 the document. The FormatOptions class is used in two different ways. A
 FormatOptions object in the Units class
 represents the default settings for the document. A FormatOptions
 object used elsewhere represents settings that may optionally override
 the default settings. The UseDefault property controls
 whether a FormatOptions object represents default or custom
 formatting. If UseDefault is true, formatting will be according to
 the default settings in the Units class, and none of the other
 settings in the object are meaningful. If UseDefault is false, the
 object contains custom settings that override the default settings in
 the Units class. UseDefault is always false for FormatOptions objects
 in the Units class.

