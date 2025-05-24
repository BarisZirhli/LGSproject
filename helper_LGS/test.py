from fpdf import FPDF
import pandas as pd

import random

columns = [
    "Id",
    "User",
    "Exam",
    "TrT",
    "TrF",
    "MthT",
    "MthF",
    "SciT",
    "SciF",
    "HistoryT",
    "HistoryF",
    "ReligionT",
    "ReligionF",
    "EngT",
    "EngF",
    "Date",
    "Grade",
]

data = []

for i in range(1, 21): 
   
    tr_t = random.randint(10, 18)
    tr_f = 18 - tr_t

    mth_t = random.randint(10, 18)
    mth_f = 17 - mth_t

    sci_t = random.randint(10, 17)
    sci_f = 17 - sci_t

    hist_t = random.randint(5, 9)
    hist_f = 9 - hist_t

    rel_t = random.randint(5, 9)
    rel_f = 10 - rel_t

    eng_t = random.randint(5, 9)
    eng_f = 10 - eng_t

    row = [
        i,  
        i, 
        1, 
        tr_t,
        tr_f,
        mth_t,
        mth_f,
        sci_t,
        sci_f,
        hist_t,
        hist_f,
        rel_t,
        rel_f,
        eng_t,
        eng_f,
        "2025-05-01",  
        8, 
    ]
    data.append(row)

df = pd.DataFrame(data, columns=columns)

pdf = FPDF()
pdf.add_page()
pdf.set_font("Arial", size=10)

pdf.set_font("Arial", style="B", size=10)
pdf.cell(220, 10, ln=1, align="C")
pdf.set_font("Arial", size=5)

col_width = 220 / len(columns)
for col in columns:
    pdf.cell(col_width - 2, 5, col + " ", border=1)
pdf.ln()


for _, row in df.iterrows():
    for item in row:
        pdf.cell(col_width - 2, 5, str(item) + " ", border=1)
    pdf.ln()


output_path = "results.pdf"
pdf.output(output_path)

output_path
