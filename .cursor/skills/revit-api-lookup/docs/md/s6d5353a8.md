---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarConstraintTargetHostFaceType
source: html/71dafbc2-6ff2-5931-9d31-66f206a65476.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintTargetHostFaceType

A type to help identify the individual face on a host element to which a Rebar handle
 is constrained.

## Syntax (C#)
```csharp
public enum RebarConstraintTargetHostFaceType
```

## Remarks
For some types of host, it is possible to describe the face in terms of recognizable
 topology (i.e. Top, Bottom, etc.). However, for most elements, the face can only be
 identified by integer tag. In all cases, a Pick to the host face can be obtained
 by calling RebarConstraint.GetTargetHostFaceReference().

