---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarHookType
source: html/3c7a78d5-f92b-e58b-e7c9-7927537498fd.htm
---
# Autodesk.Revit.DB.Structure.RebarHookType

A Rebar Hook type object that is used in the generation of Rebar.

## Syntax (C#)
```csharp
public class RebarHookType : ElementType
```

## Remarks
This object contains the definition of the hooks that may be created at the ends
 of the rebar. The specifics of these hooks are angle (range 0-PI) between first/last
 segment of rebar and the straight segment of the hook, rebar shape style and
 a multiplier used to compute the length of the straight segment of the hook.
 The default length is computed as the bar diameter * the multiplier.
 Length can be overridden by settings in the RebarBarType class.

