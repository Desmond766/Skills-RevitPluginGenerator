---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.UseDefault
source: html/e817be98-c824-0c22-bf5f-d293e67c8985.htm
---
# Autodesk.Revit.DB.FormatOptions.UseDefault Property

Indicates whether default or custom formatting should be used.

## Syntax (C#)
```csharp
public bool UseDefault { get; set; }
```

## Remarks
If UseDefault is true, formatting will be according to the default
 settings in the Units class, and none of the other settings in the
 object are meaningful. If UseDefault is false, the object contains
 custom settings that override the default settings in the Units
 class. UseDefault is always false for FormatOptions objects in the
 Units class.

