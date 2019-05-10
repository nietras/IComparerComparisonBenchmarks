## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmarkComparableClassInt32.Comparison_FromCompareToOpen()
       push    rsi
       sub     rsp,20h
       mov     rsi,rcx
       mov     rcx,7FFBDE524CF0h
       mov     edx,6
       call    coreclr!coreclr_shutdown_2+0xf230
       mov     rdx,1A2D7AE7350h
       mov     rdx,qword ptr [rdx]
       mov     rcx,rsi
       mov     rax,7FFBDE447178h
       add     rsp,20h
       pop     rsi
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [00007ffc`104b4e48],eax
       add     dword ptr [rax+40h],esp
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
; Total bytes of code 87
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].IComparer()
       mov     rdx,qword ptr [rcx+8]
       mov     rax,7FFBDE427168h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       call    00007ffb`da22a754
       jg      00007ffb`de444e2f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].Comparer()
       mov     rdx,qword ptr [rcx+10h]
       mov     rax,7FFBDE437170h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       shl     byte ptr [rdi],1
       pop     rdx
       fdivp   st(3),st
       jg      00007ffb`de454e2f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].TComparer_TComparer()
       movsx   rcx,byte ptr [rsi+38h]
       mov     byte ptr [rsp+20h],cl
       mov     rcx,qword ptr [rsi]
       mov     rdx,qword ptr [rcx+30h]
       mov     rdx,qword ptr [rdx]
       mov     rdx,qword ptr [rdx+28h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE5B2818h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rsi
       movsx   r8,byte ptr [rsp+20h]
       mov     rax,7FFBDE463EF8h
; Total bytes of code 65
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].TComparer_IComparer()
       mov     rdi,qword ptr [rsi+8]
       mov     rcx,qword ptr [rsi]
       mov     rdx,qword ptr [rcx+30h]
       mov     rdx,qword ptr [rdx]
       mov     rdx,qword ptr [rdx+28h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE5A2880h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rsi
       mov     r8,rdi
       mov     rax,7FFBDE453EF8h
; Total bytes of code 57
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].TComparer_Comparer()
       mov     rdi,qword ptr [rsi+10h]
       mov     rcx,qword ptr [rsi]
       mov     rdx,qword ptr [rcx+30h]
       mov     rdx,qword ptr [rdx]
       mov     rdx,qword ptr [rdx+28h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE592880h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rsi
       mov     r8,rdi
       mov     rax,7FFBDE443EF8h
; Total bytes of code 57
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].TComparer_Comparable()
       movsx   rcx,byte ptr [rsi+40h]
       mov     byte ptr [rsp+20h],cl
       mov     rcx,qword ptr [rsi]
       mov     rdx,qword ptr [rcx+30h]
       mov     rdx,qword ptr [rdx]
       mov     rdx,qword ptr [rdx+28h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE5C2818h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rsi
       movsx   r8,byte ptr [rsp+20h]
       mov     rax,7FFBDE473EF8h
; Total bytes of code 65
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].Comparison_FromIComparer()
       mov     rdx,qword ptr [rcx+18h]
       mov     rax,7FFBDE447178h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       shl     byte ptr [rdi],1
       pop     rbx
       fdivp   st(3),st
       jg      00007ffb`de464e2f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].Comparison_FromComparer()
       mov     rdx,qword ptr [rcx+20h]
       mov     rax,7FFBDE447178h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       shl     byte ptr [rdi],1
       pop     rbx
       fdivp   st(3),st
       jg      00007ffb`de464e2f
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromIComparer()
       mov     rdi,qword ptr [rsi+8]
       mov     rbx,qword ptr [rsi]
       mov     rcx,rbx
       mov     rdx,qword ptr [rcx+30h]
       mov     rbp,qword ptr [rdx]
       mov     rdx,qword ptr [rbp+18h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE521C40h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rdi
       mov     r8,offset System_Private_CoreLib+0x178e80
       call    coreclr!GC_Initialize+0x679e0
       mov     r14,rax
       mov     rcx,rbx
       mov     rax,qword ptr [rbp+20h]
       test    rax,rax
       jne     M00_L01
       mov     rdx,7FFBDE521D70h
       call    coreclr!GC_Initialize+0x16e20
M00_L01:
       mov     rcx,rax
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rbx
       mov     rdx,rdi
       mov     r8,r14
       call    System.Comparison`1[[System.__Canon, System.Private.CoreLib]]..ctor(System.Object, IntPtr)
       mov     rcx,rsi
       mov     rdx,rbx
       mov     rax,7FFBDE437178h
; Total bytes of code 133
```
**No ILOffsetMap found**
System.Comparison`1[[System.__Canon, System.Private.CoreLib]]..ctor(System.Object, IntPtr)

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.__Canon, System.Private.CoreLib],[IComparerComparisonBenchmarks.ComparableClassInt32TComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromComparer()
       mov     rdi,qword ptr [rsi+10h]
       mov     rbx,qword ptr [rsi]
       mov     rcx,rbx
       mov     rdx,qword ptr [rcx+30h]
       mov     rbp,qword ptr [rdx]
       mov     rdx,qword ptr [rbp+10h]
       test    rdx,rdx
       jne     M00_L00
       mov     rdx,7FFBDE521C30h
       call    coreclr!GC_Initialize+0x16e20
       mov     rdx,rax
M00_L00:
       mov     rcx,rdi
       mov     r8,offset System_Private_CoreLib+0x1b6b80
       call    coreclr!GC_Initialize+0x679e0
       mov     r14,rax
       mov     rcx,rbx
       mov     rax,qword ptr [rbp+20h]
       test    rax,rax
       jne     M00_L01
       mov     rdx,7FFBDE521D70h
       call    coreclr!GC_Initialize+0x16e20
M00_L01:
       mov     rcx,rax
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rbx
       mov     rdx,rdi
       mov     r8,r14
       call    System.Comparison`1[[System.__Canon, System.Private.CoreLib]]..ctor(System.Object, IntPtr)
       mov     rcx,rsi
       mov     rdx,rbx
       mov     rax,7FFBDE437178h
; Total bytes of code 133
```
**No ILOffsetMap found**
System.Comparison`1[[System.__Canon, System.Private.CoreLib]]..ctor(System.Object, IntPtr)

