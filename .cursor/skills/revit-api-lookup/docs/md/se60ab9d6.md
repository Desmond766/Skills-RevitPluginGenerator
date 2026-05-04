---
kind: property
id: P:Autodesk.Revit.DB.OpenOptions.AllowOpeningLocalByWrongUser
source: html/039bb499-2d04-9438-ac4c-e394dd9a0161.htm
---
# Autodesk.Revit.DB.OpenOptions.AllowOpeningLocalByWrongUser Property

Specifies whether a local file is allowed to be opened as read-only by a user other than its owner.

## Syntax (C#)
```csharp
public bool AllowOpeningLocalByWrongUser { get; set; }
```

## Remarks
The default is false. This option is ignored for central and non-workshared models.

