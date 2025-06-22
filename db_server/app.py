from db_def.db_insert_dataset import insert_dataset
from db_def.db_insert_hash import insert_hash
from db_def.db_print_dataset_table import print_dataset_table
from db_def.db_print_hash_table import print_hash_table

if __name__ == '__main__':
    #전처리된 PE 데이터가 담겨있는 csv 경로
    csv_file = r"C:\Users\admin\Desktop\data\dataset_malwares.csv"

    #전처리된 PE 데이터가 있는 csv를 DB에 저장하는 함수
    #insert_dataset(csv_file, "TEE")

    #전처리된 PE 데이터가 있는 csv를 HASH화 해서 DB에 저장하는 함수
    #insert_hash(csv_file, "HAA")

    #TEE 테이블 전체 출력
    #print_dataset_table("TEE")

    #HAA 테이블 전체 출력
    print_hash_table("HAA")