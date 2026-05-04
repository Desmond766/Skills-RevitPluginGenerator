---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterInfo.TopReferenceName
source: html/700468c3-e872-a0f3-b9cf-7afe2bc837f6.htm
---
# Autodesk.Revit.DB.Architecture.BalusterInfo.TopReferenceName Property

Represents the name of the reference for the top of this baluster or post.

## Syntax (C#)
```csharp
public string TopReferenceName { get; set; }
```

## Remarks
Two pre-defined reference names can be obtained using [!:Autodesk::Revit::DB::Architecture::BalusterInfo::getReferenceNameForHost()] or
 [!:Autodesk::Revit::DB::Architecture::BalusterInfo::getReferenceNameForTopRail()] .
 The rest of valid reference names that are allowed to be used in the setter for TopReferenceName
 are the actual names of non-continuous rails [!:Autodesk::Revit::DB::Architecture::NonContinuousRailInfo::Name] 
 in [!:Autodesk::Revit::DB::Architecture::NonContinuousRailStructure]

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The name doesn't refer to a valid reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

