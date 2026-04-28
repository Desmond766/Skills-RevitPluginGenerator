---
kind: method
id: M:Autodesk.Revit.DB.ChangeType.ConcatenateChangeTypes(Autodesk.Revit.DB.ChangeType,Autodesk.Revit.DB.ChangeType)
source: html/19faaba1-17e2-6a54-d46e-17d4a6798bfd.htm
---
# Autodesk.Revit.DB.ChangeType.ConcatenateChangeTypes Method

Creates a ChangeType that is a union of the two input ChangeTypes

## Syntax (C#)
```csharp
public static ChangeType ConcatenateChangeTypes(
	ChangeType changeType1,
	ChangeType changeType2
)
```

## Parameters
- **changeType1** (`Autodesk.Revit.DB.ChangeType`) - First input ChangeType to be concatenated
- **changeType2** (`Autodesk.Revit.DB.ChangeType`) - Second input ChangeType to be concatenated

## Returns
A new ChangeType that is a concatenation/union of the input change types

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

